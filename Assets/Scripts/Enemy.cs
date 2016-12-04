using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Enemy : MonoBehaviour {
    public float moveSpeed = 1f; 
    public GameObject enemy;
    public bool inRange = false;
    public float attackDelay = 1.0f;
    private float nextDamageEvent;
    public Animation animation;

    private Transform myTransform;
    GameObject ice_floor;//freeze
    bool freeze_enemy = false;

    float hp;//= PlayerPrefs.GetFloat("Goblin_Max_HP");

    void Awake()
    {
        myTransform = transform; 
    }

    
    void Start () {
        hp = PlayerPrefs.GetFloat("Goblin_Max_HP");
    }

 
    // Update is called once per frame
    void Update() {
        //freeze
        if (ice_floor == null)
        {
            freeze_enemy = false;
            moveSpeed = 1f;
        }
        //Kreni proti tarči
        myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;

        if (inRange == true)
        {
            Attack();
           
        }
        else
        {
            Walk();
        }

    }
    public void Attack()
    {
        animation.Play("attack");
        
        if (Time.time >= nextDamageEvent)
        {
            
            nextDamageEvent = Time.time + attackDelay;
            // Do damage here
            if(Wall.wallHealth > 0)
            {                                                  
                    Wall.wallHealth -= 10;
                    PlayerPrefs.SetFloat("Current_hp", PlayerPrefs.GetFloat("Current_hp")-10);
                    Debug.Log(Wall.wallHealth);       
            }
            else
            {
                Debug.Log("Wall destroyed.");
                inRange = false;
                //GetComponent<Animation>().Stop();
            }
        }
    }

    public void Walk()
    {
        if (freeze_enemy)
        {//freeze
            moveSpeed = 0;
            animation.Stop();
            return;
        }else if (Wall.wallHealth > 0)
        {
            animation.Play("walk");
            animation["walk"].speed = 1.5f;
            nextDamageEvent = Time.time + attackDelay;
        }
        else
        {
            moveSpeed = 0;
            animation.Stop();
            return;
        }
    }
    //Koda za freeze
    void OnCollisionEnter(Collision collisionInfo)
    {
        print("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);
        if (collisionInfo.collider.name == "projectile(Clone)")
        {
            //uzem hp
            print("uzem");
            System.Random ran = new System.Random();
            float randy = ran.Next(0, 1);
            if (randy > PlayerPrefs.GetFloat("Crit_Chance")/100) //%30 percent chance (1 - 0.7 is 0.3)
            {
                    hp = hp - 2*PlayerPrefs.GetFloat("Damage");
            }
            else
            {
                hp = hp - PlayerPrefs.GetFloat("Damage");

            }
            if (hp <= 0) {
                PlayerPrefs.SetFloat("Money",PlayerPrefs.GetFloat("Money")+1);
                Destroy(gameObject);

            }

        }
        if (collisionInfo.collider.name == "icy_floor(Clone)")
        {
            freeze_enemy = true;
            ice_floor = collisionInfo.gameObject;
        }
        /* print("There are " + collisionInfo.contacts.Length + " point(s) of contacts");
         print("Their relative velocity is " + collisionInfo.relativeVelocity);*/
    }
}
