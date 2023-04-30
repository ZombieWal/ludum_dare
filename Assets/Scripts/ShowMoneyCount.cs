using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
// using UnityEngine.SocialPlatforms.Impl;

public class ShowMoneyCount : MonoBehaviour
{
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int money = PlayerPrefs.GetInt("moneyCount");
        text.text = "$" + money.ToString();
    }
}
