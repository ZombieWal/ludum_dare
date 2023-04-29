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

    void Start()
    {
        generateHearts();
    }
    // Update is called once per frame
    void Update()
    {
        foreach (GameObject obj in hearts)
        {
            Destroy(obj);
        }
        hearts.Clear();
        generateHearts();
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

    void checkTimer()
    {
        // check currrent timer variable,if it 0 or less, heartCount - 1
        if (heartCount <= 0)
        {
            SceneManager.LoadScene("End");
        }
    } 
}