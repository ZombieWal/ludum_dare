using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
    static List<string> activeHouses;
    static List<string> housesLevel1;
    static List<string> housesLevel2;
    static List<string> housesLevel3;
    static List<string> activeCafes;
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
            "Cafe3",
            "Cafe6",
            "Cafe9",
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
        housesLevel1 = new List<string>
        {
            "House1",
            "House4",
            "House6",
            "House9",
            "House12",
            "House17",
            "House21",
            "House27",
        };
        housesLevel2 = new List<string>
        {
            "House1",
            "House4",
            "House6",
            "House9",
            "House11",
            "House12",
            "House13",
            "House16",
            "House17",
            "House19",
            "House21",
            "House23",
            "House25",
            "House27",
        };
        housesLevel3 = new List<string>
        {
            "House1",
            "House2",
            "House3",
            "House4",
            "House5",
            "House6",
            "House7",
            "House8",
            "House9",
            "House10",
            "House11",
            "House12",
            "House13",
            "House14",
            "House15",
            "House16",
            "House17",
            "House18",
            "House19",
            "House20",
            "House21",
            "House22",
            "House23",
            "House24",
            "House25",
            "House26",
            "House27",
        };
        activeCafes = cafesLevel1;
        activeHouses = housesLevel1;
        activeOrders = new List<DeliveryOrder>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public DeliveryOrder GetOrder(string name) {
        if (activeCafes.Contains(name)) {
            int houseIndex = Random.Range(0, activeHouses.Count);
            string deliverHouseName = activeHouses[houseIndex];
            Debug.Log("Create a new order from " + name + " to " + deliverHouseName);
            GameObject deliverHouse = GameObject.Find(deliverHouseName);
            
            Vector3 destination = deliverHouse.transform.position;
            DeliveryOrder new_order = new DeliveryOrder(name, deliverHouseName, destination, 10f, 100);
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
