using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    public Image timerCircle;
    public float orderTimeLimit = 60f;
    public int orderCompletionPayment;
    public int orderFailedFine;


    private float currentFillAmount;
    private float decreaseAmount;

    private float timeLeft;

    void Start()
    {
        currentFillAmount = timerCircle.fillAmount;
        decreaseAmount = currentFillAmount / orderTimeLimit;
        timeLeft = orderTimeLimit;
    }

    void Update()
    {

        // Update circular progress bar
        currentFillAmount -= decreaseAmount * Time.deltaTime;
        timerCircle.fillAmount = currentFillAmount;
        timeLeft -= Time.deltaTime;

        // destroy if too late
        if (timeLeft < 0)
        {
            int money = PlayerPrefs.GetInt("moneyCount");
            money -= orderFailedFine;
            PlayerPrefs.SetInt("moneyCount", money);
            PlayerPrefs.Save();
            Destroy(gameObject);
        }
        
        // If a drone is nearby, give order to the drone
        DroneOrderDelivery[] allDrones = FindObjectsOfType<DroneOrderDelivery>();
        foreach (DroneOrderDelivery drone in allDrones)
        {
            if (drone.CanTakeOrder() &&
                (Vector2.Distance(transform.position, drone.transform.position) < 0.2))
            {
                drone.ReceiveOrder(orderCompletionPayment, orderFailedFine);

                Destroy(gameObject);
            }
        }

    }
}
