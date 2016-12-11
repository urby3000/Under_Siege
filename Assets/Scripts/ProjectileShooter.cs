using UnityEngine;
using System.Collections;
using System.Threading;
using System.Collections.Generic;

public class ProjectileShooter : MonoBehaviour
{
    bool freeze_enemies_attack = false;
    List<GameObject> enemies_freeze_attack_list = new List<GameObject>();
    List<GameObject> ice_floor_list = new List<GameObject>();
    float freeze_time;
    float freeze_time_delay = 3f;

    GameObject prefab_projectile;
    GameObject prefab_icyprojectile;
    GameObject prefab_icyfloor;
    float attackDelay;//= 1f-PlayerPrefs.GetFloat("Attack_Speed");
    float nextDamageEvent;
    float nextSpecialAttack1;
    float nextSpecialAttack2;
    float freeze_auto_attack;
    float specialAttack1Delay = 2f;
    float specialAttack2Delay = 2f;
    float afterSpecialAttacksDelay = 0.5f;
    float afterSpecialAttacks;
    bool special_attack_1 = false;
    Vector3 a;
    RaycastHit hit_global;
    // Use this for initialization
    void Start()
    {
        attackDelay = 1f - PlayerPrefs.GetFloat("Attack_Speed")/100;
        print("attack delay: "+ attackDelay);
        prefab_projectile = Resources.Load("projectile") as GameObject;
        prefab_icyfloor = Resources.Load("icy_floor") as GameObject;

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
                    GameObject.Find("weapon").GetComponent<Renderer>().material.color = new Color(0, 0, 0);
                }
                else if (Time.time >= nextSpecialAttack2 && hit.transform.gameObject.name == "Special Attack Button 2")
                {
                    nextSpecialAttack2 = Time.time + specialAttack2Delay;
                    freeze_auto_attack = Time.time + 0.3f;
                    special_attack_2_function();
                }
                else
                {
                    if (Time.time >= freeze_auto_attack)
                    {
                        if (special_attack_1)
                        {
                            Debug.Log("Special attack 1");
                            special_attack_1 = false;
                            hit_global = hit;
                            special_attack_1_function();
                            Invoke("special_attack_1_function", 0.3f);
                            Invoke("special_attack_1_function", 0.6f);
                            GameObject.Find("weapon").GetComponent<Renderer>().material.color = new Color(0.82f, 0.18f, 0.18f);
                            afterSpecialAttacks = Time.time + afterSpecialAttacksDelay;
                        }
                        else if (Time.time >= afterSpecialAttacks)
                        {
                            a = hit.point;
                            a.x = a.x * 30;
                            a.z = a.z * 30;
                            a.y = a.y * 30;
                            GameObject.Find("weapon").transform.LookAt(a);
                            if (Time.time >= nextDamageEvent)
                            {
                                nextDamageEvent = Time.time + attackDelay;
                                GameObject projectile = Instantiate(prefab_projectile) as GameObject;
                                projectile.transform.position = GameObject.Find("weapon").transform.position + new Vector3(0, 0.5f, 0);
                                projectile.transform.LookAt(hit.point);
                                hit.point = hit.point;
                                Rigidbody rb = projectile.GetComponent<Rigidbody>();
                                a = hit.point;
                                //Debug.Log(a);
                                a.y = a.y - 1f;
                                //a.y = -0.01f;
                                a=a.normalized;
                                rb.velocity = a * 50;

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
    public void special_attack_1_function()
    {
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
        foreach (GameObject projectile in projectiles)
        {
            Quaternion rotation = Quaternion.Euler(0, angle, 0);
            projectile.transform.position = GameObject.Find("weapon").transform.position + new Vector3(0, 0.86f, 0);
            //Debug.Log(hit_global.point + " " + hit_global.point.normalized);
            a = rotation * hit_global.point.normalized;
            projectile.transform.LookAt(rotation * hit_global.point);
            a.y = -0.07f;
            projectile.GetComponent<Rigidbody>().velocity = rotation * a * 100;
            angle = angle - 2;
        }
    }
    public void special_attack_2_function()
    {
        enemies_freeze_attack_list.Clear();
        ice_floor_list.Clear();
        freeze_enemies_attack = true;
        foreach (var enemy in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (enemy.name == "goblinv10(Clone)")
            {
                enemies_freeze_attack_list.Add(enemy);
                GameObject ice_floor = Instantiate(prefab_icyfloor) as GameObject;
                ice_floor.transform.position = enemy.transform.GetChild(1).position;
                Destroy(ice_floor, 2);
                /* GameObject projectile = Instantiate(prefab_icyprojectile) as GameObject;
                 freeze_attack_projectiles.Add(projectile);
                 projectile.transform.position = new Vector3(0, 2.22f, 0);// GameObject.Find("Special Attack Button 2").transform.position + new Vector3(0, 2.22f, 0);
                 projectile.transform.LookAt(enemy.transform.GetChild(1).position);
                 Rigidbody rb = projectile.GetComponent<Rigidbody>();
                 rb.useGravity = false;*/

            }
        }

        freeze_time = Time.time + freeze_time_delay;
    }
}



