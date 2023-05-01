using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DroneOrderDelivery : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public bool CanTakeOrder()
    {
        // TODO: check if delivering something already
        return true;

    }


    public void ReceiveOrder(int orderCompletionPayment, int orderFailedFine)
    {
        // TODO: activate destination, pay only if reached 
        int money = PlayerPrefs.GetInt("moneyCount");
        money += orderCompletionPayment;
        PlayerPrefs.SetInt("moneyCount", money);
        PlayerPrefs.Save();
    }
}
