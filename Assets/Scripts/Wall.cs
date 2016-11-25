using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

    public static int wallHealth = 500;
    //public GameObject Wall

	// Use this for initialization
	void Start () {

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
