using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float moveSpeed = 1f; 
    public int health = 10;
    public GameObject enemy;
    public bool inRange = false;
    public float attackDelay = 1.0f;
    private float nextDamageEvent;
    public Animation animation;

    private Transform myTransform;

    
    void Awake()
    {
        myTransform = transform; 
    }

    
    void Start () {
        
    }

 
    // Update is called once per frame
    void Update() {

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
        if (Wall.wallHealth > 0)
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
}
