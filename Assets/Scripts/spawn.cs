using UnityEngine;
using System.Collections;

public class spawn : MonoBehaviour {
    
   
    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    public GameObject kocka;                                        
    void Start () {
        enemy = (GameObject)Resources.Load("goblinv10", typeof(GameObject));
        InvokeRepeating("Spawn", spawnTime, spawnTime);  
    }
	
	// Update is called once per frame
	void Spawn () {
        if(Wall.wallHealth <= 0)
        {
            return;
        }

        Vector3 pos = transform.position;

        int zOs = Random.Range(-5, 5);
        pos.z = zOs;
        pos.y = transform.position.y + 2;
        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemy, pos, transform.rotation); 
    }

}
