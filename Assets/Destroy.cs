using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {   //ne dela
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>()); 
        }
    }

}
