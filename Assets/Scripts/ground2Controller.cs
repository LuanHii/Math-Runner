using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ground2Controller : MonoBehaviour
{
    public TMP_Text TMP;
    public Transform choices;

    public void UpdateText(string newText)
    {
        TMP.text = newText;
    }

    public int num1;
    public int num2;
    public int operation;
    public float result;

    public string textResult;

    void Start()
    {
        num1 = Random.Range(1, 11);
        num2 = Random.Range(1, 11);
        operation = Random.Range(1, 3);

        if (operation == 1)
            result = num1 + num2;
        else
            result = num1 * num2;

        int indexRightChoice = Random.Range(0, 2);
        for (int i = 0; i < 2; i++)
        {
            Transform escolha = choices.GetChild(i);
            if (i == indexRightChoice)
                escolha.GetComponent<TMP_Text>().text = result.ToString();
            else
            {
                int wrongChoice = Random.Range(1, 21);
                if (wrongChoice == result)
                {
                    wrongChoice++;
                    if (wrongChoice > 20)
                        wrongChoice = 1;
                }
                escolha.GetComponent<TMP_Text>().text = wrongChoice.ToString();
            }
        }

        if (operation == 1)
            textResult = num1 + " + " + num2 + " = ?";
        else
            textResult = num1 + " x " + num2 + " = ?";
    }

    void Update()
    {

    }
}
