using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MathQuestionController : MonoBehaviour
{
    public TMP_Text operationText;
    public TMP_Text scoreText;
    public int PlayerPoints;
    public GameObject parentImage;
   
    
    
   [SerializeField] ground2Controller question; 
    void Start()
    {
       scoreText.text = "Pontos: " + PlayerPoints.ToString();
       parentImage.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (question == null) {
    question = FindObjectOfType<ground2Controller>();
    if (question != null) {
        Debug.Log("Objeto question encontrado!");
        operationText.text = question.textResult;
        parentImage.SetActive(true);  
    } else {
        Debug.Log("Objeto question NÃO encontrado!");
    }
}

        scoreText.text = PlayerPoints.ToString();
         
    }
}
