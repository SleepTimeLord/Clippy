using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroductionTextScript : MonoBehaviour
{
    public GameObject OHHS;
    private List<string> dialogues = new List<string>{"It all started in August when we all got the news.", "Clippy, the beloved Oxon Hill High School mascot, was killed.", "Principal Holland announced this a few days before school started.", "Unironically, this is my first day here. I don’t know what to expect.", "**Loud school bell rings**", "“Crap, what bell is this?”", "**A large crowd of students flood the halls, quickly making their way to their respective classes**" };
    public TextWriter textWriter;
    private Text text;
    private int currentDialogue = 0;
    private bool stop = false;


    private void Awake()
    {
        text = GameObject.Find("TextOB").GetComponent<Text>();
    }

    private void Start()
    {
        //text.text = "APPLES! APPLES, APPLES, APPLES, APPLES, APPLES, APPLES!";
        textWriter.AddWriter(text, dialogues[currentDialogue], .1f);
    }

    private void Update()
    {
        if(currentDialogue >= 3 && stop != true)
        {
            stop = true;
            GameObject.Find("DeadClippy").gameObject.SetActive(false);
            OHHS.gameObject.SetActive(true);
        }
    }

    public void ButtonPress()
    {
        if (textWriter.next != true)
        {
            textWriter.next = true;
            text.text = dialogues[currentDialogue];
        }
        else if (textWriter.next == true && currentDialogue < 6)
        {
            textWriter.next = false;
            text.text = "";
            currentDialogue++;
            textWriter.AddWriter(text, dialogues[currentDialogue], .1f);
        }
        else if (textWriter.next == true && currentDialogue == 6)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
