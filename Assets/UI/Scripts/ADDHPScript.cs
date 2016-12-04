using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ADDHPScript : MonoBehaviour {

    // Use this for initialization
    



    private float currentHp = 0;
    private float currentAD = 0;
    private float currentATK = 0;
    private float currentCRT = 0;
    private int priceHP = 1;
    private int priceAD = 1;
    private int priceATK = 1;
    private int priceCRT = 1;
    public float tocke = 100;

    GameObject goScore;
    Text score;

    GameObject hp;
    GameObject goPriceHP;
    GameObject buttonHP;
    Button HP;
    Text hpText;
    Text priceHPP;

    GameObject goAD;
    Text adText;
    GameObject goPriceAD;
    Text priceADD;
    GameObject buttonAD;
    Button AD;

    GameObject goATK;
    Text atkText;
    GameObject goPriceATK;
    Text priceATKK;
    GameObject buttonATK;
    Button ATK;

    GameObject goCRT;
    Text crtText;
    GameObject goPriceCRT;
    GameObject buttonCRT;
    Text priceCRTT;
    Button CRT;

    void Start()
    {

        print("Wall hp: " + PlayerPrefs.GetFloat("Wall_HP"));
        print("Mage max hp: " + PlayerPrefs.GetFloat("Mage_Max_HP"));
        print("goblin max hp: " + PlayerPrefs.GetFloat("Goblin_Max_HP"));
        print("attack speed: " + PlayerPrefs.GetFloat("Attack_Speed"));
        print("damage: " + PlayerPrefs.GetFloat("Damage"));
        print("crit chance: " + PlayerPrefs.GetFloat("Crit_Chance"));
        print("money: " + PlayerPrefs.GetFloat("Money"));

        tocke = PlayerPrefs.GetFloat("Money");
        currentHp = PlayerPrefs.GetFloat("Wall_HP");
        currentAD = PlayerPrefs.GetFloat("Damage");
        currentATK = PlayerPrefs.GetFloat("Attack_Speed");
        currentCRT = PlayerPrefs.GetFloat("Crit_Chance");

        goScore = GameObject.Find("ScoreText");
        score = goScore.GetComponent<Text>();
        score.text = tocke + "";

        hp = GameObject.Find("HPText");
        hpText = hp.GetComponent<Text>();
        hpText.text = "HP: " + currentHp;

        goPriceHP = GameObject.Find("PriceHPText");
        priceHPP = goPriceHP.GetComponent<Text>();
        priceHPP.text = "Price: " + priceHP;

        goAD = GameObject.Find("ADText");
        adText = goAD.GetComponent<Text>();
        adText.text = "AD: " + currentAD;
        goPriceAD = GameObject.Find("ADPriceText");
        priceADD = goPriceAD.GetComponent<Text>();
        priceADD.text = "Price: " + priceAD;

        goATK = GameObject.Find("ATKText");
        atkText = goATK.GetComponent<Text>();
        atkText.text = "ATK: " + currentATK;
        goPriceATK = GameObject.Find("ATKPriceText");
        priceATKK = goPriceATK.GetComponent<Text>();
        priceATKK.text = "Price: " + priceATK;

        goCRT = GameObject.Find("CRTText");
        crtText = goCRT.GetComponent<Text>();
        crtText.text = "CRT: " + currentCRT;
        goPriceCRT = GameObject.Find("CRTPriceText");
        priceCRTT = goPriceCRT.GetComponent<Text>();
        priceCRTT.text = "Price: " + priceCRT;

        HP = GameObject.Find("PlusButtonHP").GetComponent<Button>();
        HP.onClick.AddListener(AddHP);

        HP = GameObject.Find("PlusButtonAD").GetComponent<Button>();
        HP.onClick.AddListener(AddAD);

        HP = GameObject.Find("PlusButtonATK").GetComponent<Button>();
        HP.onClick.AddListener(AddATK);

        HP = GameObject.Find("PlusButtonHPCRT").GetComponent<Button>();
        HP.onClick.AddListener(AddCRT);





    }
    void Update()
    {
       //tocke = 100;
    }

    public void AddHP()
    {
        //goScore = GameObject.Find("ScoreText");
       // score = goScore.GetComponent<Text>();

        hp = GameObject.Find("HPText");
        hpText = hp.GetComponent<Text>();

        goPriceHP = GameObject.Find("PriceHPText");
        priceHPP = goPriceHP.GetComponent<Text>();

        float temp = tocke - priceHP;
        
        if(temp >= 0)
        {
            PlayerPrefs.SetFloat("Wall_HP",PlayerPrefs.GetFloat("Wall_HP")+10);
            float tmp = tocke - priceHP;
            tocke = tmp;
            PlayerPrefs.SetFloat("Money", tmp);
            score.text = "" + tocke;

            currentHp = currentHp + 10;
            hpText.text = "HP: " + currentHp;
            print(currentHp);


            //priceHP = priceHP + 5;
            //priceHPP.text = "Price: " + priceHP;
        }
        else
        {
            buttonHP = GameObject.Find("PlusButtonHP");
            HP = buttonHP.GetComponent<Button>();
            HP.enabled = false;
        }

        
    }

    public void AddAD()
    {
        // goScore = GameObject.Find("ScoreText");
        // score = goScore.GetComponent<Text>();

        goAD = GameObject.Find("ADText");
        adText = goAD.GetComponent<Text>();

        goPriceAD = GameObject.Find("ADPriceText");
        priceADD = goPriceAD.GetComponent<Text>();

        float temp = tocke - priceAD;

        if (temp >= 0)
        {
            PlayerPrefs.SetFloat("Damage", PlayerPrefs.GetFloat("Damage") + 1);
            float tmp = tocke - priceAD;
            tocke = tmp;
            PlayerPrefs.SetFloat("Money", tmp);
            score.text = "" + tocke;

            currentAD = currentAD + 1;
            adText.text = "AD: " + currentAD;


            //priceAD = priceAD + 5;
            //priceADD.text = "Price: " + priceAD;
        }
        else
        {
            buttonAD = GameObject.Find("PlusButtonAD");
            AD = buttonAD.GetComponent<Button>();
            AD.enabled = false;
        }


    }
    public void AddATK()
    {
        //goScore = GameObject.Find("ScoreText");
        //score = goScore.GetComponent<Text>();

        goATK = GameObject.Find("ATKText");
        atkText = goATK.GetComponent<Text>();

        goPriceATK = GameObject.Find("ATKPriceText");
        priceATKK = goPriceATK.GetComponent<Text>();

        float temp = tocke - priceATK;

        if (temp >= 0)
        {
            PlayerPrefs.SetFloat("Attack_Speed", PlayerPrefs.GetFloat("Attack_Speed") + 1);
            tocke = tocke - priceATK;
            score.text = "" + tocke;

            PlayerPrefs.SetFloat("Money", temp);
            currentATK = currentATK + 1;
            atkText.text = "ATK: " + currentATK;


            //priceATK = priceATK + 5;
            //priceATKK.text = "Price: " + priceATK;
        }
        else
        {
            buttonATK = GameObject.Find("PlusButtonATK");
            ATK = buttonATK.GetComponent<Button>();
            ATK.enabled = false;
        }


    }
    public void AddCRT()
    {
        //goScore = GameObject.Find("ScoreText");
        //score = goScore.GetComponent<Text>();

        goCRT = GameObject.Find("CRTText");
        crtText = goCRT.GetComponent<Text>();

        goPriceCRT = GameObject.Find("CRTPriceText");
        priceCRTT = goPriceCRT.GetComponent<Text>();

        float temp = tocke - priceCRT;

        if (temp >= 0)
        {
            PlayerPrefs.SetFloat("Crit_Chance", PlayerPrefs.GetFloat("Crit_Chance") + 1);

            tocke = tocke - priceCRT;
            score.text = "" + tocke;

            PlayerPrefs.SetFloat("Money", temp);
            currentCRT = currentCRT + 1;
            crtText.text = "CRT: " + currentCRT;


            //priceCRT = priceCRT + 5;
            //priceCRTT.text = "Price: " + priceCRT;
        }
        else
        {
            buttonCRT = GameObject.Find("PlusButtonHPCRT");
            CRT = buttonCRT.GetComponent<Button>();
            CRT.enabled = false;
        }


    }

}
