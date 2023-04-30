using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class UpgradeSpeed : MonoBehaviour
{
    public Button button;
    public TMP_Text buttonText;
    public UpgradeScript upgradeScript;

    readonly List<string> upgradeNames = new List<string>() {"Speed +10", "Speed +15", 
        "Speed +20", "Fully Upgraded"};
    readonly List<int> upgradeCost = new List<int>() {100, 200, 400, -1};

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

        // TODO: change speed in PlayerPrefs

        PlayerPrefs.Save();
    }
}
