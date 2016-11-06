using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public Transform target;
    public int moveSpeed;
    public int rotationSpeed;

    private Transform myTransform;


    void Awake()
    {
        myTransform = transform; 
    }

    void Start () {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
	}

    // Update is called once per frame
    void Update () {

        Debug.DrawLine(target.position, myTransform.position, Color.blue);

        //Da gleda v tarčo
        //myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);

        //Kreni proti tarči
        myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
        Attack();
        //OnTriggerEnter();

    }
    public void Attack()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);
        //Debug.Log(distance);
        Debug.Log(myTransform.position.x);
        if(distance < 1.5)
        {
           // moveSpeed = 0;
        }
        //ko je mob dost blizu zida za melle attack se ustavi
        if(myTransform.position.x +1.5 > target.position.x)
        {
            moveSpeed = 0;
        }
        //TODO: mob začne napadat zid

    }



}
