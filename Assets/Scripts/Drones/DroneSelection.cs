using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class DroneSelection : MonoBehaviour
{
    public Button button;
    public TMP_Text status;
    bool isClicked = false;
    public static List<GameObject> droneButtons = new List<GameObject>();
    void Start()
    {
        button.onClick.AddListener(OnButtonClick);

    }

    // Update is called once per frame
    private void OnButtonClick()
    {
        if (isClicked)
            return;

        status.rectTransform.position = new Vector2(48, -50);
        //button.rectTransform.position = new Vector2(-250, -220);

        isClicked = true;
    }
}
