using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("moneyCount", 0);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int money = PlayerPrefs.GetInt("moneyCount");
            money += 20;
            PlayerPrefs.SetInt("moneyCount", money);
            PlayerPrefs.Save();
        }

    }
}
