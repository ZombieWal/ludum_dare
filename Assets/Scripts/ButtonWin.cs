using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonWin : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGameAgain()
    {
        Debug.Log("Win Button works");
        SceneManager.LoadScene("Game");
    }
}
