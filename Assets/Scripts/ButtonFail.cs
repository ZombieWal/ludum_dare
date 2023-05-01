using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFail : MonoBehaviour
{
    public void StartGameAgain()
    {
        Debug.Log("Button works");
        SceneManager.LoadScene("Game");
    }
}
