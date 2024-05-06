using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    public GameObject Palidino;
    public GameObject PalidinoClassroom;
    private List<string> dialogues = new List<string> { "This place is Like a Maze!", "Luckily, I found someone; or someone found me.", "Mr. Paladino: \"Hey, you look lost. Need any directions?\"" , "Nunu: \"I'm looking for Mr. Paladino's class.\"", "Mr. Paladino: \"That's me. let me take you to my class.\"", "Nunu: \"This class is huge. I never expected an art room to be so-\"", "Mr Paladino seems to have fallen asleep, and a snot bubble has formed.", "The bell rings once again, and numerous students swarm the room", "The snot bubble suddenly pops as Paladino springs up", "Mr. Paladino: \"Good morning, class!\"", "Mr. Paladino: \"You might’ve caught me sleeping, but you’ll never catch Jeff sleeping!\"", "Mr. Paladino: \"Cause he’s already dead!\"", "Mr. Paladino plays a laugh soundtrack on the loudspeaker", "Nunu: \"This is better than last year’s art teacher. That’s for sure.\"" };
    public TextWriter textWriter;
    private Text text;
    private int currentDialogue = 0;
    private bool stop = false;
    private bool stop2 = false;
    private bool stop3 = false;


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
        if (currentDialogue > 1 && stop != true)
        {
            stop = true;
            Palidino.SetActive(true);
        } else if( currentDialogue > 4 && stop2 != true)
        {
            stop2 = true;
            Palidino.SetActive(false);
            GameObject.Find("Hallway").gameObject.SetActive(false);
            PalidinoClassroom.SetActive(true);
        } else if(currentDialogue > 8 && stop3 != true)
        {
            stop3 = true;
            Palidino.SetActive(true);
        }
    }

    public void ButtonPress()
    {
        if (textWriter.next != true)
        {
            textWriter.next = true;
            text.text = dialogues[currentDialogue];
        }
        else if (textWriter.next == true && currentDialogue < 13)
        {
            textWriter.next = false;
            text.text = "";
            currentDialogue++;
            textWriter.AddWriter(text, dialogues[currentDialogue], .1f);
        }
        else if (textWriter.next == true && currentDialogue == 13)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
