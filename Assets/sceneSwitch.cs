using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneSwitch : MonoBehaviour
{
    public Text theText;

    void Start()
    {
        theText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    public void pointerEnter()
    {
        theText.color = Color.white; //Or however you do your color
    }

    public void pointerExit()
    {
        theText.color = Color.green; //Or however you do your color
    }
    
    public void goToGame()
    {
        SceneManager.LoadScene("mainGame");
    }

}
