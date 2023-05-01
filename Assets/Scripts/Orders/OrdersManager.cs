using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryOrder {
    public string pickup;
    public string deliverPlace;
    public Vector3 destination;
    public float timeout;
    public int cost;

    public DeliveryOrder(string pickup, string deliverPlace, Vector3 destination, float timeout, int cost)
    {
        this.pickup = pickup;
        this.deliverPlace = deliverPlace;
        this.destination = destination;
        this.timeout = timeout;
        this.cost = cost;
    }
}

public class OrdersManager : MonoBehaviour
{
    static List<string> housesLevel1;
    static List<string> cafesLevel1;
    static List<string> cafesLevel2;
    static List<string> cafesLevel3;
    static List<DeliveryOrder> activeOrders;

    // Start is called before the first frame update
    void Start()
    {
        cafesLevel1 = new List<string>
        {
            "Cafe1",
            "Cafe4",
            "Cafe6",
            "Cafe9",
            "Cafe11",
            "Cafe14",
            "Cafe17"
        };
        cafesLevel2 = new List<string>
        {
            "Cafe1",
            "Cafe4",
            "Cafe6",
            "Cafe9",
            "Cafe11",
            "Cafe14",
            "Cafe17",
            "Cafe2",
            "Cafe3",
            "Cafe8",
            "Cafe10",
            "Cafe13",
            "Cafe15"
        };
        cafesLevel3 = new List<string>
        {
            "Cafe1",
            "Cafe4",
            "Cafe6",
            "Cafe9",
            "Cafe11",
            "Cafe14",
            "Cafe17",
            "Cafe2",
            "Cafe3",
            "Cafe8",
            "Cafe10",
            "Cafe13",
            "Cafe15",
            "Cafe5",
            "Cafe7",
            "Cafe12",
            "Cafe16",
            "Cafe18"
        };
        activeOrders = new List<DeliveryOrder>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public DeliveryOrder? GetOrder(string name) {
        if (cafesLevel1.Contains(name)) {
            Debug.Log("Create a new order from " + name);
            Vector3 destination = GameObject.Find("House1").transform.position;
            DeliveryOrder new_order = new DeliveryOrder(name, "House1", destination, 10f, 100);
            activeOrders.Add(new_order);
            return new_order;
        }
        return null;

    }

    static public void DeliverOrder(DeliveryOrder order)
    {
        Debug.Log("Delivered order from " + order.pickup + " to " + order.destination);
        activeOrders.Remove(order);
        int money = PlayerPrefs.GetInt("moneyCount");
        money += order.cost;
        PlayerPrefs.SetInt("moneyCount", money);
        PlayerPrefs.Save();

    }
}
