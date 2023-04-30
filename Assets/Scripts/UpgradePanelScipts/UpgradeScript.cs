using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class UpgradeScript : MonoBehaviour
{

    public int upgradeCost;
    public BarScript progressBar;
    public Button button;
    public TMP_Text upgradeCostText;
    public TMP_Text buyText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (upgradeCost > 0)
        {
            progressBar.SetMax(upgradeCost);
            upgradeCostText.text = "$" + upgradeCost.ToString();
        }
        else
        {
            progressBar.Disable();
            button.interactable = false;
            upgradeCostText.text = "";
            buyText.text = "";
            return;
        }
        int money = PlayerPrefs.GetInt("moneyCount");
        if (money < upgradeCost) {
            progressBar.SetProgress(money);
            button.interactable = false;
        } else {
            progressBar.SetProgress(upgradeCost);
            button.interactable = true;
        }
    }
}
