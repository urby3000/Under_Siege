using UnityEngine;
using System.Collections;

public class ProjectileShooter : MonoBehaviour
{
    GameObject prefab_projectile;

    // Use this for initialization
    void Start()
    {
        prefab_projectile = Resources.Load("projectile") as GameObject;

    }
    
    void Update()
    {


    }
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {

            GameObject projectile = Instantiate(prefab_projectile) as GameObject;
            projectile.transform.position = GameObject.Find("weapon").transform.position + new Vector3(0, 0.5f, 0);

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
            {
               /* Debug.DrawRay(ray.origin, ray.direction * 1000);
                Debug.Log(hit.point);*/
            }
            projectile.transform.LookAt(hit.point);
            hit.point = hit.point.normalized;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = hit.point * 100;

        }

    }


}
