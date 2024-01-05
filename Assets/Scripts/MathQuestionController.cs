using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MathQuestionController : MonoBehaviour
{
    public TMP_Text operationText;
    public TMP_Text scoreText;
    public int PlayerPoints;
    
    
   [SerializeField] ground2Controller question; 
    void Start()
    {
       scoreText.text = "Pontos: " + PlayerPoints.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (question == null) {
            question = FindObjectOfType<ground2Controller>();
            operationText.text = question.textResult;
        }

        scoreText.text = "Pontos: " + PlayerPoints.ToString();
         
    }
}
