using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public TMP_Text quest;
    int count = 0;

    public DroneMovement drone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            count += 1;
            if (count == 1)
            {
                quest.text = "Welcome to your working place! \n Press space bar";
            }
            if (count == 2)
            {
                quest.text = "Your job is to control delivery drone!";
            }
            if (count == 3)
            {
                quest.text = "Here it is, in the left corner!";
            }
            if (count == 4)
            {
                quest.text = "And the sma-a-all green dot on the map";
            }
            if (count == 5)
            {
                quest.text = "The drone has hearts, but they don't work";
            }
            if (count == 6)
            {
                quest.text = "You know, these game jams";
            }
            if (count == 7)
            {
                quest.text = "Anyway, you can control drone with arrows";
            }
            if (count == 8)
            {
                quest.text = "Or WASD, if you prefer";
            }
            if (count == 9)
            {
                quest.text = "It is not working yet, it is on purpose";
            }
            if (count == 10)
            {
                quest.text = "So, you need to pickup orders from shops";
            }
            if (count == 11)
            {
                quest.text = "Small red buildings, I know, I know";
            }
            if (count == 12)
            {
                quest.text = "And deliver them to flashing triangles!";
            }
            if (count == 13)
            {
                quest.text = "They will appear soon, I promise!";
            }
            if (count == 14)
            {
                quest.text = "From deliveries you get money";
            }
            if (count == 15)
            {
                quest.text = "From money - upgrades";
            }
            if (count == 16)
            {
                quest.text = "You can increase drone speed";
            }
            if (count == 17)
            {
                quest.text = "Or spawn more orders";
            }
            if (count == 18)
            {
                quest.text = "And your final goal is automation!";
            }
            if (count == 19)
            {
                quest.text = "Too much talk, too little work";
            }
            if (count == 20)
            {
                quest.text = "Let's get started!";
                drone.isActivated = true;
            }
            
        }
    }
}
