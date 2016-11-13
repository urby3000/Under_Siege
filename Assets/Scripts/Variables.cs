using UnityEngine;
using System.Collections;

public class Variables : MonoBehaviour {

    float damage = 10;
    // Use this for initialization
    void Start () {
        //Debug.Log("Dela");
	}
	
	// Update is called once per frame
	void Update () {

    }
    public float getDamage()
    {
        return damage;
    }
}
