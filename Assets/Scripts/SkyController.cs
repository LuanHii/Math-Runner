using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyController : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    private Renderer skyRenderer;
    public Light directionalLight; // Referência para a luz direcional
    public GameController gameController;

    void Start()
    {
        skyRenderer = GetComponent<Renderer>();
    }

    void Update()
    {

        if (!gameController.pause) {
            float offsetX = Time.time * scrollSpeed;
            float offsetY = Time.time * scrollSpeed;
            Vector2 newOffset = new Vector2(offsetX, offsetY);

            skyRenderer.material.SetTextureOffset("_MainTex", newOffset);

            // Ajustar a direção da luz com base na posição atual do céu
            directionalLight.transform.rotation = Quaternion.Euler(90 - offsetY * 360, offsetX * 360, 0);
        }
        
    }
}
