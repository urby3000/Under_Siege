using UnityEngine;
using System.Collections;

public class fireBall : MonoBehaviour {


    // Use this for initialization
    public Rigidbody rb;
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(10, 5, 0, ForceMode.Impulse);
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
