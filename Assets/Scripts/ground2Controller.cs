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

        result = (operation == 1) ? num1 + num2 : num1 * num2;

        int indexRightChoice = Random.Range(0, 2);
        for (int i = 0; i < 2; i++)
        {
            Transform escolha = choices.GetChild(i);
            TMP_Text textComponent = escolha.GetComponent<TMP_Text>();

            if (i == indexRightChoice)
            {
                textComponent.text = result.ToString();
                textComponent.tag = "RightChoice";
            }
            else
            {
                int wrongChoice;
                do
                {
                    wrongChoice = Random.Range(1, 21);
                } while (wrongChoice == result);

                textComponent.text = wrongChoice.ToString();
                textComponent.tag = "WrongChoice";
            }
            Debug.Log("Tag do objeto " + textComponent.name + " é: " + escolha.tag);
        }

        textResult = (operation == 1) ? num1 + " + " + num2 : num1 + " x " + num2;
    }

    void Update()
    {

    }
}
