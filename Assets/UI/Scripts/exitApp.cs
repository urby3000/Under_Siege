using UnityEngine;
using System.Collections;

public class exitApp : MonoBehaviour {

	// Use this for initialization
	public void ExitApp()
    {
        //Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
