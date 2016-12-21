using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

    public static float wallHealth = 500;
    //public GameObject Wall

	// Use this for initialization
	void Start () {
        wallHealth = PlayerPrefs.GetFloat("Wall_HP");

    }
	
	// Update is called once per frame
	void Update () {
        if(wallHealth < 1)
        {
            Destroy(gameObject);
            Debug.Log("Wall destroyed.");
        }
	
	}
}
