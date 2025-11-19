using UnityEngine;
using TMPro;
using System.Collections;

public class Number : MonoBehaviour
{
    public TextMeshProUGUI output;
    public TMP_Text input;
    public string text;
    [SerializeField] private int number;
    [SerializeField] private int answer;
    [SerializeField] private float clearDelay;

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
        clearDelay = 2f;
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
    IEnumerator WaitAndClear()
    {
        yield return new WaitForSeconds(clearDelay);
        if(output.text == "Code Accepted" || output.text =="Code Denied")
            output.text = "Please Enter Code";
    }

    public void CodeSubtract()
    {
        if (output.text == "Please Enter Code" || output.text == "Code Denied" || output.text == "Code Accepted")
            return;    
        output.text = output.text.Substring(0, output.text.Length - 1);
        if(output.text == "")
        {
            output.text = "Please Enter Code";
        }
    }

    public void CodeSubmit()
    {
        if (output.text == answer.ToString())
        {
            output.text = "Code Accepted";
            StartCoroutine(WaitAndClear());
            //TELL PLAYER THE CODE WAS ACCEPTED
            Destroy(this.gameObject);
        }
        else
        {
            output.text = "Code Denied";
            StartCoroutine(WaitAndClear());
        }
    }
}
