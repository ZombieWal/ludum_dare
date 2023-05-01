using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
    static List<string> housesLevel0;
    static List<string> housesLevel1;
    static List<string> housesLevel2;
    static List<string> housesLevel3;
    static List<string> activeCafes;
    static List<string> cafesLevel0;
    static List<string> cafesLevel1;
    static List<string> cafesLevel2;
    static List<string> cafesLevel3;
    static List<DeliveryOrder> activeOrders;

    // Start is called before the first frame update
    void Start()
    {
        cafesLevel0 = new List<string>
        {
            "Cafe1",
            "Cafe3",
            "Cafe6",
            "Cafe9",
        };
        cafesLevel1 = new List<string>
        {
            "Cafe1",
            "Cafe2",
            "Cafe8",
            "Cafe9",
            "Cafe10",
            "Cafe11",
            "Cafe15",
            "Cafe17"
        };
        cafesLevel2 = new List<string>
        {
            "Cafe1",
            "Cafe2",
            "Cafe3",
            "Cafe5",
            "Cafe7",
            "Cafe8",
            "Cafe9",
            "Cafe10",
            "Cafe11",
            "Cafe13",
            "Cafe15",
            "Cafe17"
        };
        cafesLevel3 = new List<string>
        {
            "Cafe1",
            "Cafe2",
            "Cafe3",
            "Cafe4",
            "Cafe5",
            "Cafe6",
            "Cafe7",
            "Cafe8",
            "Cafe9",
            "Cafe10",
            "Cafe11",
            "Cafe12",
            "Cafe13",
            "Cafe14",
            "Cafe15",
            "Cafe16",
            "Cafe17"
        };
        housesLevel0 = new List<string>
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
        housesLevel1 = new List<string>
        {
            "House1",
            "House4",
            "House6",
            "House9",
            "House11",
            "House12",
            "House13",
            "House16",
            "House19",
            "House21",
            "House23",
            "House27",
        };
        housesLevel2 = new List<string>
        {
            "House1",
            "House2",
            "House4",
            "House6",
            "House9",
            "House11",
            "House12",
            "House13",
            "House14",
            "House15",
            "House16",
            "House19",
            "House21",
            "House23",
            "House24",
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
        UpgradeCity(0);
        activeOrders = new List<DeliveryOrder>();
    }

    static public void UpgradeCity(int level)
    {
        if (level == 0)
        {
            activeCafes = cafesLevel0;
            activeHouses = housesLevel0;
        }
        if (level == 1)
        {
            activeCafes = cafesLevel1;
            activeHouses = housesLevel1;
        }
        if (level == 2)
        {
            activeCafes = cafesLevel2;
            activeHouses = housesLevel2;
        }
        if (level == 3)
        {
            activeCafes = cafesLevel3;
            activeHouses = housesLevel3;
        }

        foreach (string obj in activeCafes) {
            GameObject cafe = GameObject.Find(obj);
            cafe.transform.position = new Vector3(cafe.transform.position.x, cafe.transform.position.y, -2);
        }

        foreach (string obj in activeHouses)
        {
            GameObject cafe = GameObject.Find(obj);
            cafe.transform.position = new Vector3(cafe.transform.position.x, cafe.transform.position.y, -2);
        }

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
