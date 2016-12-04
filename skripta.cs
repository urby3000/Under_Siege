using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class skripta : MonoBehaviour {

    // Use this for initialization
    public Canvas quit_menu;
    public Button SelectStage_button;
    public Button Exit_button;

    void Start()
    {
        SelectStage_button = SelectStage_button.GetComponent<Button>();
        Exit_button = Exit_button.GetComponent<Button>();
        quit_menu.enabled = false;

    }
    public void ExitPress()
    {
        quit_menu.enabled = true;
        SelectStage_button.enabled = false;
        Exit_button.enabled = false;


    }
    public void noPress()
    {
        quit_menu.enabled = false;
        SelectStage_button.enabled = true;
        Exit_button.enabled = true;
    }
    public void StartLevel()
    {
        Application.LoadLevel(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
