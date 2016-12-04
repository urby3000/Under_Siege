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
    void OnCollisionEnter(Collision collisionInfo)
    {
        print("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);
        //if (collisionInfo.collider.name == "projectile(Clone)")
        //{
        //    //uzem hp
        //    print("uzem");

        //}
        //if (collisionInfo.collider.name == "icy_floor(Clone)")
        //{
        //    freeze_enemy = true;
        //    ice_floor = collisionInfo.gameObject;
        //}
        /* print("There are " + collisionInfo.contacts.Length + " point(s) of contacts");
         print("Their relative velocity is " + collisionInfo.relativeVelocity);*/
    }
}
