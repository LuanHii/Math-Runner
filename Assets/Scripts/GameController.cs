using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    public TMP_Text gameOverText;
    
    public GameObject gameOver;
    public GameObject gameManager;
    public AudioSource audioSource;

    public Button pauseButton;
    public Sprite playImg;
    public Sprite pauseImg;
    
    public bool isLosing = false;
    public bool pause = false;
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
        gameOverText.text = "Acertou: " + mathScript.PlayerPoints.ToString(); 
        
        
    }

    IEnumerator VoltarParaOMenu()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("Menu"); 
    }

    public void PausaJogo(){
       
        
        if (!pause)
        {
            Time.timeScale = 0;
            audioSource.Pause();
            pause = true;
            pauseButton.image.sprite = playImg;
        } 
        else {
            Time.timeScale = 1;
            audioSource.Play();
            pause = false;
            pauseButton.image.sprite = pauseImg;
        }
        

    }
}
