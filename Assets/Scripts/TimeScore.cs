using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimeScore : MonoBehaviour
{
    public TextMeshProUGUI timeText, coinsText;
    public int coins, totalCoins;

    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        coins = 0;
        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        timeText.text = "0.00s";
        coinsText.text = "0/0";
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        string seconds = (time % 60).ToString("0#.00");
        string minutes = Mathf.FloorToInt(time/60).ToString("0#");

        timeText.text = minutes + ":" + seconds;

        if (totalCoins == 0)
        {
            coinsText.text = "";
        }
        else
        {
            coinsText.text = "Coins Collected: " + coins.ToString() + "/" + totalCoins.ToString();
        }

        if (coins == totalCoins)
        {
            time -= Time.deltaTime;
            gameObject.transform.Find("Particle System").gameObject.SetActive(true);
        }
    }
}
