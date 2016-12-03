using UnityEngine;
using System.Collections;

public class CollisionDetectionMage : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log(name + " is in range");

            GetComponent<Animation>().Stop();
            //to je zato, da lahka spreminjam variable v "Enemy" brez da je spremenljivka static
            GameObject theEnemy = this.gameObject;
            EnemyMage EnemyScript = theEnemy.GetComponent <EnemyMage>();
            EnemyScript.inRange = true;
            EnemyScript.moveSpeed = 0;

        }
    }
}
