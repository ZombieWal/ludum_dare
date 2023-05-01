using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class UpgradeQuantity : MonoBehaviour
{
    public Button button;
    public TMP_Text buttonText;
    public UpgradeScript upgradeScript;

    readonly List<string> upgradeNames = new List<string>() {"+1 Robot", "+1 Robot",
        "+1 Robot", "Fully Upgraded"};
    readonly List<int> upgradeCost = new List<int>() { 300, 300, 300, -1 };

    int currentUpdateCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        buttonText.text = upgradeNames[currentUpdateCount];
        upgradeScript.upgradeCost = upgradeCost[currentUpdateCount];

        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        if (currentUpdateCount >= upgradeCost.Count)
            return;

        int money = PlayerPrefs.GetInt("moneyCount");
        if (money < upgradeScript.upgradeCost)
            return;

        money -= upgradeScript.upgradeCost;
        PlayerPrefs.SetInt("moneyCount", money);

        currentUpdateCount += 1;
        buttonText.text = upgradeNames[currentUpdateCount];
        upgradeScript.upgradeCost = upgradeCost[currentUpdateCount];

        foreach (DroneMovement drone in DroneMovement.drones)
        {
            string droneName = "Drone" + (currentUpdateCount+1);
            if (drone.name == droneName)
            {
                Debug.Log("Activate Voltrone, oh. no activate " + droneName);
                drone.SelectAsActivated();
                drone.SelectAsControlled();
                break;
            }
        }

        PlayerPrefs.Save();
    }
}
