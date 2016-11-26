using UnityEngine;
using System.Collections;

public class CollisionDetection : MonoBehaviour {

	void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log(name + " Collided");

            GetComponent<Animation>().Stop();
            //to je zato, da lahka spreminjam variable v "Enemy" brez da je spremenljivka static
            GameObject theEnemy = this.gameObject;         
            Enemy EnemyScript = theEnemy.GetComponent<Enemy>();
            EnemyScript.inRange = true;
            EnemyScript.moveSpeed = 0;

        }
    }
}
