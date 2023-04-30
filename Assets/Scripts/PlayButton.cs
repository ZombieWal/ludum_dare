using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public Button playButton;

    void Start()
    {
        Button btn = playButton.GetComponent<Button>();
        btn.onClick.AddListener(PlayGame);
    }
    public void PlayGame()
    {
        Debug.Log("Button was clicked");
        SceneManager.LoadScene("Game");
    }
}
