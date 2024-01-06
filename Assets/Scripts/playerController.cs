using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Transform playerTransform;
    private Vector2 dragStartPosition;
    [SerializeField] private GameObject gameManager;
    public GameObject canvas;
    private UnityEngine.Animator anim;
    private Vector3 camPos;
    [SerializeField] private AudioClip rightAnswerAudio;
    [SerializeField] private AudioClip wrongAnswerAudio;
    [SerializeField] private AudioClip wooshAudio;







    private bool isDragging = false;

    public float dragThreshold = 50.0f;
    public float moveSpeed = 5.0f;
    public float runSpeed = 3f;
    public float laneWidth = 4.0f;
    private bool lane1 = true;
    private bool lane2 = false;
    private float targetXPosition;
    float timer = 0f;
    float increaseSpeedInterval = 3f;

    void Start()
    {
        playerTransform = transform;
        targetXPosition = playerTransform.position.x;
        anim = GetComponentInChildren<Animator>();



    }

    void Update()
    {
        camPos = Camera.main.transform.position;
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
        timer += Time.deltaTime;



        float speedMultiplier = runSpeed / moveSpeed;
        anim.SetFloat("animationSpeed", speedMultiplier * 2);



        if (timer >= increaseSpeedInterval)
        {
            if (runSpeed < 50)
            {
                runSpeed += 1;
            }

            timer = 0f;
        }
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
            AudioSource.PlayClipAtPoint(wooshAudio, camPos);
        }
        else if (target == -laneWidth / 2f)
        {
            lane1 = true;
            lane2 = false;
            AudioSource.PlayClipAtPoint(wooshAudio, camPos);
        }
    }

    void SmoothMove()
    {
        float currentX = playerTransform.position.x;
        float newX = Mathf.MoveTowards(currentX, targetXPosition, moveSpeed * Time.deltaTime);
        playerTransform.position = new Vector3(newX, playerTransform.position.y, playerTransform.position.z);
    }

    void OnCollisionExit(Collision collision)
    {
        MathQuestionController mathScript = gameManager.GetComponent<MathQuestionController>();
        Image parentImage = mathScript.operationText.GetComponentInParent<Image>();


        if (collision.gameObject.CompareTag("RightChoice"))
        {

            BrilhoTela brilhoScript = canvas.GetComponentInChildren<BrilhoTela>();
            brilhoScript.IniciarBrilho(0.7f, true);
            mathScript.PlayerPoints++;
            mathScript.operationText.text = "";
            parentImage.enabled = false;
            AudioSource.PlayClipAtPoint(rightAnswerAudio, camPos);
            Debug.Log("acertou");




        }

        else if (collision.gameObject.CompareTag("WrongChoice"))
        {
            BrilhoTela brilhoScript = canvas.GetComponentInChildren<BrilhoTela>();
            brilhoScript.IniciarBrilho(0.7f, false);
            mathScript.PlayerPoints--;
            mathScript.operationText.text = "";
            parentImage.enabled = false;
            AudioSource.PlayClipAtPoint(wrongAnswerAudio, camPos);
            Debug.Log("errou");
        }
    }
}
