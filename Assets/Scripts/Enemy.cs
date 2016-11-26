using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 1f;
    public int health = 10;
    public GameObject enemy;
    public bool inRange = false;
    public float attackDelay = 1.0f;
    private float nextDamageEvent;
    public Animation animation;


    GameObject ice_floor;//freeze
    bool freeze_enemy = false;

    private Transform myTransform;


    void Awake()
    {
        myTransform = transform;
    }


    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        //freeze
        if (ice_floor == null) {
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
            if (Wall.wallHealth > 0)
            {
                Wall.wallHealth -= 10;
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
        }
        else if (Wall.wallHealth > 0)
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
        }
        if (collisionInfo.collider.name == "icy_floor(Clone)") {
            freeze_enemy = true;
            ice_floor = collisionInfo.gameObject;
        }
        /* print("There are " + collisionInfo.contacts.Length + " point(s) of contacts");
         print("Their relative velocity is " + collisionInfo.relativeVelocity);*/
    }
}
