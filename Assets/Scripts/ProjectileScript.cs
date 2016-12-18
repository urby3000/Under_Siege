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
        if (collision.gameObject.tag == "Enemy")
        {
            ParticleSystem hit = (ParticleSystem)Instantiate(on_hit_green, collision.contacts[0].point, new Quaternion());
            Destroy(hit, 1);
            Destroy(gameObject, 1.1f);
        }
        else
        {
            ParticleSystem hit = (ParticleSystem)Instantiate(on_hit, collision.contacts[0].point, new Quaternion());
            Destroy(hit, 1);
            Destroy(gameObject, 1.1f);
        }
    }
}
