using UnityEngine;
using System.Collections;
using System.Threading;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileShooter : MonoBehaviour
{
    GameObject prefab_projectile;
    float attackDelay = 1f;
    float nextDamageEvent;
    float nextSpecialAttack1;
    float freeze_auto_attack;
    float specialAttack1Delay = 2f;
    float afterSpecialAttacksDelay = 0.5f;
    float afterSpecialAttacks;
    bool special_attack_1 = false;
    Vector3 a;
    RaycastHit hit_global;
    // Use this for initialization
    void Start()
    {
        prefab_projectile = Resources.Load("projectile") as GameObject;
        GameObject.Find("zid").GetComponent<Renderer>().material.color = new Color(0.5f, 1, 1);
        GameObject.Find("weapon").GetComponent<Renderer>().material.color = new Color(0, 0, 0);
    }

    void Update()
    {


    }
    void FixedUpdate()
    {


        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
            { //Debug.DrawRay(ray.origin, ray.direction * 1000);
              //Debug.Log(hit.point);
                if (Time.time >= nextSpecialAttack1 && hit.transform.gameObject.name == "Special Attack Button 1")
                {
                    nextSpecialAttack1 = Time.time + specialAttack1Delay;
                    freeze_auto_attack = Time.time + 0.3f;
                    special_attack_1 = true;
                    GameObject.Find("weapon").GetComponent<Renderer>().material.color = new Color(255, 255, 255);
                }
                else
                {
                    if (Time.time >= freeze_auto_attack)
                    {
                        if (special_attack_1)
                        {
                            Debug.Log("Special attack");
                            special_attack_1 = false;
                            hit_global = hit;
                            special_attack_1_function();
                            Invoke("special_attack_1_function", 0.3f);
                            Invoke("special_attack_1_function", 0.6f);
                            GameObject.Find("weapon").GetComponent<Renderer>().material.color = new Color(0, 0, 0);
                            afterSpecialAttacks = Time.time + afterSpecialAttacksDelay;
                        }
                        else if(Time.time>= afterSpecialAttacks)
                        {
                            a = hit.point;
                            a.x = a.x * 30;
                            a.z = a.z * 30;
                            GameObject.Find("weapon").transform.LookAt(a);
                            if (Time.time >= nextDamageEvent)
                            {
                                nextDamageEvent = Time.time + attackDelay;
                                GameObject projectile = Instantiate(prefab_projectile) as GameObject;
                                projectile.transform.position = GameObject.Find("weapon").transform.position + new Vector3(0, 0.5f, 0);
                                projectile.transform.LookAt(hit.point);
                                hit.point = hit.point.normalized;
                                Rigidbody rb = projectile.GetComponent<Rigidbody>();
                                a = hit.point;
                                a.y = 0;
                                rb.velocity = a * 100;

                            }

                        }
                    }

                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
        }
    }
    public void special_attack_1_function() {

        List<GameObject> projectiles = new List<GameObject>();
        for (int i = 0; i < 11; i++)
        {
            projectiles.Add(Instantiate(prefab_projectile) as GameObject);
        }
        a = hit_global.point;
        a.x = a.x * 30;
        a.z = a.z * 30;
        GameObject.Find("weapon").transform.LookAt(a);
        int angle = 10;
        for (int i = 0; i < 11; i++)
        {
            Quaternion rotation = Quaternion.Euler(0, angle, 0);
            projectiles[i].transform.position = GameObject.Find("weapon").transform.position + new Vector3(0, 0.86f, 0);
            Debug.Log(hit_global.point + " " + hit_global.point.normalized);
            a = rotation * hit_global.point.normalized;
            projectiles[i].transform.LookAt(rotation * hit_global.point);
            a.y = 0;
            projectiles[i].GetComponent<Rigidbody>().velocity = rotation * a * 100;
            angle = angle - 2;
        }
    }
}



