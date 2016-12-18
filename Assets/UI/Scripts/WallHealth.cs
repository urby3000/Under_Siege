using UnityEngine;
using System.Collections;

public class WallHealth : MonoBehaviour {

    public float max_health = 100f;
    public float health = 0f;
    public GameObject bar;

	// Use this for initialization
	void Start () {
        health = max_health;
        health = PlayerPrefs.GetFloat("Current_hp");
        decreaseHealth();
        //InvokeRepeating("decreaseHealth", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void decreaseHealth()
    {
        health -= 2f;
        float calc_health = health / max_health;
        setHealthBar(calc_health);
    }
    void setHealthBar(float myhealth)
    {
        bar.transform.localScale = new Vector3(myhealth, bar.transform.localScale.y, bar.transform.localScale.z);
    }
}
