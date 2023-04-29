using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class DeliveryManager : MonoBehaviour
{
    private bool deliveryCheck = false;
    public float deliveryCount = 10;
    public DialogueRunner dialogueRunner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (deliveryCheck == true)
        {
            dialogueRunner.StartDialogue("Start");
        }
        if (deliveryCount == 0)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
