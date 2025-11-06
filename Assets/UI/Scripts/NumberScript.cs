using UnityEngine;
using TMPro;

public class Number : MonoBehaviour
{
    public TextMeshProUGUI output;
    public TMP_Text input;
    public string text;
    [SerializeField] private int number;
    [SerializeField] private int answer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input.text = number.ToString();
        if(number < 0)
        {
            input.text = "X";
        }
        if (number > 9)
        {
            input.text = "E";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CodeAdd()
    {
        if (output.text == "Please Enter Code" || output.text == "Code Denied" || output.text == "Code Accepted")
        {
            output.text = "";
            output.text += number.ToString();
        }
        else
        {
            output.text += number.ToString();
        }
    }

    public void CodeSubtract()
    {
        output.text = output.text.Substring(0, output.text.Length - 1);
        if(output.text == "")
        {
            output.text = "Please Enter Code";
        }
    }

    public void CodeSubmit()
    {
        if(output.text == answer.ToString())
        {
            output.text = "Code Accepted";
        }
        else
        {
            output.text = "Code Denied";
        }
        // Intentionally left blank
    }
}
