using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MathQuestionController : MonoBehaviour
{
    [SerializeField] public TMP_Text operationText;
    
   [SerializeField] ground2Controller question; 
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (question == null) {
            question = FindObjectOfType<ground2Controller>();
            operationText.text = question.textResult;
        }
         
    }
}
