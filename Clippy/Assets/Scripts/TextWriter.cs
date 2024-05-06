using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    private Text uiText;
    private string textToWrite;
    private int characterIndex;
    private float timePerCharacter;
    private float timer;
    public bool next = false;
    public void AddWriter(Text uiText, string textToWrite, float timePerCharacter)
    {
        this.uiText = uiText;
        this.textToWrite = textToWrite;
        this.timePerCharacter = timePerCharacter;
        characterIndex = 0;
    }

    private void Update()
    {
        if (uiText != null && next != true)
        {
            timer -= Time.deltaTime;
            while(timer<= 0f)
            {
                //next char

                timer += timePerCharacter;
                characterIndex++;
                uiText.text = textToWrite.Substring(0, characterIndex);

                if(characterIndex >= textToWrite.Length)
                {
                    next = true;
                    uiText = null;
                    return;
                }

            }

        }
    }
}
