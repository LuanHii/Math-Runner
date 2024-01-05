using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform playerTransform;
    private Vector2 dragStartPosition;
    private bool isDragging = false;

    public float dragThreshold = 50.0f;
    public float moveSpeed = 5.0f;
    public float runSpeed = 3f;
    public float laneWidth = 4.0f;
    private bool lane1 = true;
    private bool lane2 = false;
    private float targetXPosition;

    void Start()
    {
        playerTransform = transform;
        targetXPosition = playerTransform.position.x;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            dragStartPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (isDragging)
            {
                float dragDelta = Input.mousePosition.x - dragStartPosition.x;

                if (Mathf.Abs(dragDelta) > dragThreshold)
                {
                    if (dragDelta > 0 && lane1)
                        SetTargetPosition(laneWidth / 2f);
                    else if (dragDelta < 0 && lane2)
                        SetTargetPosition(-laneWidth / 2f);
                }
            }
            isDragging = false;
        }

        SmoothMove();
    }

    void SetTargetPosition(float target)
    {
        targetXPosition = target;
        if (target == laneWidth / 2f)
        {
            lane1 = false;
            lane2 = true;
        }
        else if (target == -laneWidth / 2f)
        {
            lane1 = true;
            lane2 = false;
        }
    }

    void SmoothMove()
    {
        float currentX = playerTransform.position.x;
        float newX = Mathf.MoveTowards(currentX, targetXPosition, moveSpeed * Time.deltaTime);
        playerTransform.position = new Vector3(newX, playerTransform.position.y, playerTransform.position.z);
    }
}
