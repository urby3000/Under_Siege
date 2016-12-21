using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour
{
    public ParticleSystem on_hit;
    public ParticleSystem on_hit_green;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
       // gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        Physics.gravity = new Vector3(0, -4.0F, 0);
        gameObject.GetComponent<Rigidbody>().mass = 10;
        gameObject.GetComponent<Rigidbody>().useGravity = true;


        if (collision.gameObject.tag == "Enemy")
        {
            ParticleSystem hit = (ParticleSystem)Instantiate(on_hit_green, collision.contacts[0].point, new Quaternion());
            //Destroy(hit, 1);
            Destroy(gameObject,1f);
        }
        else
        {
            ParticleSystem hit = (ParticleSystem)Instantiate(on_hit, collision.contacts[0].point, new Quaternion());
           // Destroy(hit, 1);
            Destroy(gameObject, 1f);
        }
    }
}
