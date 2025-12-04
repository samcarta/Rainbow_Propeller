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
    [SerializeField] private AudioSource buttonSound;
    [SerializeField] private AudioClip buttonSoundClip;
    [SerializeField] GameObject NumberPad;
    private bool correctCode = false;
    [SerializeField] GameObject vault;

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

    private string findNewInsult()
    {
        string[] insults = {"Wrong Code!", "Incorrect", "Nope", "Try Again", "kys", "torta pounder" };
        int randIndex = Random.Range(0, 100);
        if(randIndex < 25)
        {
            return insults[0];
        }
        else if (randIndex < 50)
        {
            return insults[1];
        }
        else if (randIndex < 70)
        {
            return insults[2];
        }
        else if (randIndex < 90)
        {
            return insults[3];
        }
        else if (randIndex < 99)
        {
            return insults[4];
        }
        else
        {
            return insults[5];
        }
    }

    public void CodeAdd()
    {
        buttonSound.PlayOneShot(buttonSoundClip);
        if (output.text == "Code Denied" || output.text == "Code Accepted")
        {
            output.text = "";
            output.text += number.ToString();
        }
        else
        {
            if(output.text.Length >= 4)
            {
                return;
            }
            output.text += number.ToString();
        }
    }
    IEnumerator WaitAndClear()
    {
        yield return new WaitForSeconds(clearDelay);
        if(output.text != "Code Accepted")
            output.text = "";
    }

    public void Close()
    {
        NumberPad.SetActive(false);
    }

    public void CodeSubtract()
    {
        if (output.text == "kys" || output.text == "Code Accepted" || output.text == "Wrong Code!" || output.text == "Incorrect" || output.text == "Nope" || output.text == "Try Again")
            return;
        if (output.text.Length != 0)
        {
            output.text = output.text.Substring(0, output.text.Length - 1);
        }
    }

    IEnumerator Wait5()
    {
        //this.gameObject.SetActive(false);
        yield return new WaitForSeconds(5f);
        correctCode = false;
    }

    public void CodeSubmit()
    {
        if (output.text == answer.ToString())
        {
            output.text = "Code Accepted";
            vault.SetActive(true);
            StartCoroutine(WaitAndClear());
            correctCode = true;
            StartCoroutine(Wait5());
        }
        else
        {
            //display.text = findNewInsult();
            output.text = findNewInsult();
            StartCoroutine(WaitAndClear());
        }
    }
}
