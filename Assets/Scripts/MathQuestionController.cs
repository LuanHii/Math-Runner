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
    public UnityEngine.UI.Image parentImage;
    
    
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
            parentImage.enabled = true;
            
            
        }

        scoreText.text = "Pontos: " + PlayerPoints.ToString();
         
    }
}
