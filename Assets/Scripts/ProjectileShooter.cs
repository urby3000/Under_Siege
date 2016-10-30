using UnityEngine;
using System.Collections;

public class ProjectileShooter : MonoBehaviour {

    GameObject prefab;


    // Use this for initialization
    void Start ()
    {
        Debug.Log("I am alive!");
        prefab = Resources.Load("projectile") as GameObject;
    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            
                GameObject projectile = Instantiate(prefab) as GameObject;
                projectile.transform.position = new Vector3(-9.79f, -0.385f, -2.08f);
                Rigidbody rb = projectile.GetComponent<Rigidbody>();

                rb.AddForce(new Vector3(20, 0, 0) * (300));

            

        }
    }
}
