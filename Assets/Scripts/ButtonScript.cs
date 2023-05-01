using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    // Update is called once per frame
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
}
