using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GenMenuScript : MonoBehaviour
{
    public Canvas popUp;
    private bool popOn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && popOn == false)
        {
            popOn = true;
            Time.timeScale = 0;
            popUp.gameObject.SetActive(true);
        } else if(Input.GetKeyDown(KeyCode.Escape) && popOn == true)
        {
            popOn = false;
            Time.timeScale = 1;
            popUp.gameObject.SetActive(false);
        }
    }

    public void ButtonPress2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
