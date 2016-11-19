using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ADDHPScript : MonoBehaviour {

    // Use this for initialization
    
    private int currentHp = 0;
    private int currentAD = 0;
    private int currentATK = 0;
    private int currentCRT = 0;
    private int priceHP = 1;
    private int priceAD = 1;
    private int priceATK = 1;
    private int priceCRT = 1;
    public int tocke = 100;

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
        priceADD.text = "Price: " + priceHP;

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

        int temp = tocke - priceHP;
        
        if(temp >= 0)
        {
            int tmp = tocke - priceHP;
            tocke = tmp;
            score.text = "" + tocke;

            currentHp = currentHp + 1;
            hpText.text = "HP: " + currentHp;


            priceHP = priceHP + 5;
            priceHPP.text = "Price: " + priceHP;
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

        int temp = tocke - priceAD;

        if (temp >= 0)
        {
            int tmp = tocke - priceAD;
            tocke = tmp;
            score.text = "" + tocke;

            currentAD = currentAD + 1;
            adText.text = "AD: " + currentAD;


            priceAD = priceAD + 5;
            priceADD.text = "Price: " + priceAD;
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

        int temp = tocke - priceATK;

        if (temp >= 0)
        {
            tocke = tocke - priceATK;
            score.text = "" + tocke;

            currentATK = currentATK + 1;
            atkText.text = "ATK: " + currentATK;


            priceATK = priceATK + 5;
            priceATKK.text = "Price: " + priceATK;
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

        int temp = tocke - priceCRT;

        if (temp >= 0)
        {
            
            tocke = tocke - priceCRT;
            score.text = "" + tocke;

            currentCRT = currentCRT + 1;
            crtText.text = "CRT: " + currentCRT;


            priceCRT = priceCRT + 5;
            priceCRTT.text = "Price: " + priceCRT;
        }
        else
        {
            buttonCRT = GameObject.Find("PlusButtonHPCRT");
            CRT = buttonCRT.GetComponent<Button>();
            CRT.enabled = false;
        }


    }

}
