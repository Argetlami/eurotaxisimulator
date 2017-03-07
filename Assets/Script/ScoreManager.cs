using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static double money;

    Text moneyfield;

    void Start()
    {
		moneyfield = GameObject.Find("MoneyAmount").GetComponent<Text>();
        money = 0;
    }

    void Update()
    {
        if (money < 0)
            money = 0;
        moneyfield.text = "" + money;
    }

    public static void addMoney (double profit)
    {
        if (!PlayerController.frozen)
        {
            money += profit;
        }
    }
    public static void reset()
    {
        money = 0;
    }
}
