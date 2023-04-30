using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class UpgradeCity : MonoBehaviour
{
    public Button button;
    public TMP_Text buttonText;
    public UpgradeScript upgradeScript;

    readonly List<string> upgradeNames = new List<string>() {"City I", "City II", 
        "City III", "Fully Upgraded"};
    readonly List<int> upgradeCost = new List<int>() {200, 500, 1000, -1};

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

        // TODO: change map

        PlayerPrefs.Save();
    }
}
