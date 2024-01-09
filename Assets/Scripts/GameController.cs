using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    public TMP_Text gameOverText;
    
    public GameObject gameOver;
    public GameObject gameManager;
    
    public bool isLosing = false;
    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void LostGame()
    {
        isLosing = true;
        player.runSpeed = 0;
        gameOver.SetActive(true);
        MathQuestionController mathScript = gameManager.GetComponent<MathQuestionController>();
        gameOverText.text = "Acertou: " + mathScript.PlayerPoints.ToString() + " contas!"; 
        
        
    }

    IEnumerator VoltarParaOMenu()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("Menu"); 
    }
}
