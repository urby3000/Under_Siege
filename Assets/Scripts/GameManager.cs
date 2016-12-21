using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    float current_hp=100;//= PlayerPrefs.GetFloat("Wall_HP");
    

	// Use this for initialization
	void Start () {
        //print("Wall hp: "+PlayerPrefs.GetFloat("Wall_HP"));
        //print("Mage max hp: " + PlayerPrefs.GetFloat("Mage_Max_HP"));
        //print("goblin max hp: " + PlayerPrefs.GetFloat("Goblin_Max_HP"));
        //print("attack speed: " + PlayerPrefs.GetFloat("Attack_Speed"));
        //print("damage: " + PlayerPrefs.GetFloat("Damage"));
        //print("crit chance: " + PlayerPrefs.GetFloat("Crit_Chance"));
        //print("money: " + PlayerPrefs.GetFloat("Money"));
        

        current_hp = PlayerPrefs.GetFloat("Current_hp");
        PlayerPrefs.SetFloat("Mage_Max_HP",12);
        PlayerPrefs.SetFloat("Goblin_Max_HP", 12);
    }
	
	// Update is called once per frame
	void Update () {
        current_hp = PlayerPrefs.GetFloat("Current_hp");
        if (current_hp <= 0) {
            Time.timeScale = 0;
        }
	
	}
}
