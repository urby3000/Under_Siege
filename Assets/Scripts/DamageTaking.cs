using UnityEngine;
using System.Collections;

public class DamageTaking : MonoBehaviour {

    float health = 100;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        Variables a = collisionInfo.collider.GetComponent<Variables>();
        float score = a.getDamage();
        health = health - score;

        Debug.Log("Health: " + health);
        /*Debug.Log("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);
        Debug.Log("There are " + collisionInfo.contacts.Length + " point(s) of contacts");
        Debug.Log("Their relative velocity is " + collisionInfo.relativeVelocity);*/

    }
    /*void OnCollisionStay(Collision collisionInfo)
    {
        //print(gameObject.name + " and " + collisionInfo.collider.name + " are still colliding");
    }
    void OnCollisionExit(Collision collisionInfo)
    {
        //print(gameObject.name + " and " + collisionInfo.collider.name + " are no longer colliding");
    }*/
}
