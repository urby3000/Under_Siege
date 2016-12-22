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
       // print("attack delay: "+ attackDelay);
        prefab_projectile = Resources.Load("projectile") as GameObject;
        prefab_icyfloor = Resources.Load("ice_rock") as GameObject;

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
            { Debug.DrawRay(ray.origin, ray.direction * 1000);
              Debug.Log(hit.point);
                if (Time.time >= nextSpecialAttack1 && hit.transform.gameObject.name == "Special Attack Button 1")
                {
                    nextSpecialAttack1 = Time.time + specialAttack1Delay;
                    freeze_auto_attack = Time.time + 0.3f;
                    special_attack_1 = true;
                   // GameObject.Find("weapon").GetComponent<Renderer>().material.color = new Color(0, 0, 0);
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
                            special_attack_1 = false;
                            hit_global = hit;
                            special_attack_1_function();
                            Invoke("special_attack_1_function", 0.6f);
                            //GameObject.Find("weapon").GetComponent<Renderer>().material.color = new Color(0.82f, 0.18f, 0.18f);
                            afterSpecialAttacks = Time.time + afterSpecialAttacksDelay;
                        }
                        else if (Time.time >= afterSpecialAttacks)
                        {
                            GameObject.Find("weapon").transform.LookAt(hit.point*30);
                            if (Time.time >= nextDamageEvent)
                            {
                                nextDamageEvent = Time.time + attackDelay;
                                GameObject projectile = Instantiate(prefab_projectile) as GameObject;
                                projectile.transform.position = GameObject.Find("weapon").transform.position;
                                a = hit.point;
                                a = a.normalized;
                                a.y = 0.001f;
                                projectile.transform.LookAt(a*50);
                                projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * 50;

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
        GameObject projectile;
        GameObject.Find("weapon").transform.LookAt(hit_global.point * 30);
        int angle = 2;
        for (int i = 0; i < 2; i++)
        {
            projectile=Instantiate(prefab_projectile) as GameObject;
            Quaternion rotation = Quaternion.Euler(0, angle, 0);
            projectile.transform.position = GameObject.Find("weapon").transform.position;
            a = rotation * hit_global.point;
            projectile.transform.LookAt(a);
            projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * 40;
            angle = angle - 4;

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

            }
        }

        freeze_time = Time.time + freeze_time_delay;
    }
}



