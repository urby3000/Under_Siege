using UnityEngine;
using System.Collections;

public class EnemyMage : MonoBehaviour
{

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

    public GameObject fireBallV2;
    public GameObject attackSpawnPoint;
    void Start()
    {
        fireBallV2 = (GameObject)Resources.Load("fireBall", typeof(GameObject));
        attackSpawnPoint = GameObject.Find("spawnPoint");
    }


    // Update is called once per frame
    void Update()
    {

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
    int var = 1;
    public void Attack()
    {
        animation.Play("attack");

        Vector3 pos = attackSpawnPoint.transform.position;
        if (animation["attack"].time > 0.6 && animation["attack"].time < 1.3 && var == 1)
        {
            Instantiate(fireBallV2, pos, transform.rotation);
            var = 0;
        }

        if (Time.time >= nextDamageEvent)
        {

            nextDamageEvent = Time.time + attackDelay;
            // Do damage here
            if (Wall.wallHealth > 0)
            {
                var = 1;
                Wall.wallHealth -= 10;
                Debug.Log(Wall.wallHealth);
            }
            else
            {
                Debug.Log("Wall destroyed.");
                inRange = false;
                animation.Stop();
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
