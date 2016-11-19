using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ESCButton : MonoBehaviour {
    public GameObject goMenuPanel;
    public Canvas cavas;
    public GameObject goStatsPanel;
    public GameObject goSelectStagePanel;
    private bool isShowing = false;
  
    void Start()
    {

    }
	// Update is called once per frame
	void Update () {
        //goCanvas = GameObject.Find("MenuPanel");

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!cavas.enabled)
            {
                goMenuPanel.gameObject.SetActive(true);
                Debug.Log(goMenuPanel);
                goStatsPanel.gameObject.SetActive(false);
                goSelectStagePanel.gameObject.SetActive(false);
            }
            isShowing = !isShowing;
            cavas.enabled = isShowing;

        }
        
    }
    
}
