using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Value : MonoBehaviour
{
    private TextMeshProUGUI valueText;
    private Image square;
    public float valueG;
    // Start is called before the first frame update
    void Start()
    {
        valueText = GameObject.Find("Value").GetComponent<TextMeshProUGUI>();
        square = GameObject.Find("ImageSquare").GetComponent<Image>();
        valueG = 0;
    }

    // Update is called once per frame
    void Update()
    {
        valueText.text = valueG.ToString();

        if (valueG == 100) square.color = Color.green;
        else if (valueG == -100) square.color = Color.red;
        else square.color = Color.white;
    }
}
