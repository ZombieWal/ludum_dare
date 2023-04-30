using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HeartManager : MonoBehaviour
{
    public GameObject heart;
    public List<GameObject> hearts;
    private GameObject newHeart;
    public float heartCount = 3;

    private float prevHeartCount;

    void Start()
    {
        hearts = new List<GameObject>();
        prevHeartCount = heartCount;
        generateHearts();
    }
    // Update is called once per frame
    void Update()
    {
        if (heartCount != prevHeartCount)
        {
            UpdateHearts();
            prevHeartCount = heartCount;
        }
    }

    void generateHearts()
    {
        checkTimer();
        for (int i = 0; i < heartCount; i++)
        {
            newHeart = Instantiate(heart, gameObject.transform);
            hearts.Add(newHeart);
        }
    }

    void UpdateHearts()
    {
        // Remove existing hearts
        foreach (GameObject obj in hearts)
        {
            Destroy(obj);
        }
        hearts.Clear();

        // Generate new hearts
        generateHearts();
        checkTimer();
    }

    void checkTimer()
    {
        // check currrent timer variable,if it 0 or less, heartCount - 1
        if (heartCount <= 0)
        {
            SceneManager.LoadScene("Fail");
        }
    } 
}