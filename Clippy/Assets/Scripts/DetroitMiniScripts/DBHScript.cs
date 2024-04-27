using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DBHScript : MonoBehaviour
{

    private Value valueScript;
    // Start is called before the first frame update
    void Start()
    {
        valueScript = GameObject.Find("Empty").GetComponent<Value>();

        if (gameObject.tag == "BadButton")
        {
            gameObject.GetComponent<Button>().onClick.AddListener(Down);

        }
        else if (gameObject.tag == "GoodButton")
        {
            gameObject.GetComponent<Button>().onClick.AddListener(Up);
        }
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void Up()
    {
        if(valueScript.valueG < 100) //Code
        {
            valueScript.valueG += 10;
        }
    }

    public void Down()
    {
        if (valueScript.valueG > -100)
        {
            valueScript.valueG -= 10;
        }
    }
}
