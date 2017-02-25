using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxiMeter : MonoBehaviour {

    public float targetTime;
    private float timer;

    private void Start()
    {
        ScoreManager.addMoney(6.00);
    }
	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;

        if (timer <= 0.0f)
        {
            timerEnded();
        }

    }

    void timerEnded()
    {
        ScoreManager.addMoney(1.57);
        timer = targetTime;
    }
}
