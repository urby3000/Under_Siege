using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetFloat("Current_hp",PlayerPrefs.GetFloat("Wall_HP"));
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collisionInfo)
    {
        print("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);
        
        /* print("There are " + collisionInfo.contacts.Length + " point(s) of contacts");
         print("Their relative velocity is " + collisionInfo.relativeVelocity);*/
    }
}
