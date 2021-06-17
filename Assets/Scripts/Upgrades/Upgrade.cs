using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public TextMeshProUGUI nameTextbox;
    public TextMeshProUGUI descriptionTextbox;
    public string upgradeName;
    public string upgradeDescription;
    public int cost;
    public bool upgradePurchased;

    public void Awake()
    {
        nameTextbox = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        descriptionTextbox = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        transform.GetChild(2).GetComponent<UpgradePurchaseButton>().upgrade = this;
        transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = cost.ToString();
    }
    public void GetText()
    {
        nameTextbox.text = upgradeName;
        descriptionTextbox.text = upgradeDescription;
    }

    public virtual void UpgradeEffect()
    {

    }

    public virtual void PurchaseUpgrade()
    {
        if (upgradePurchased == false)
        {
            if (UpgradeSystem.current.currentData >= cost)
            {
                UpgradeSystem.current.currentData -= cost;
                UpgradeEffect();
                Debug.Log("Upgrade Purchased.");
                UpgradeSystem.current.ownedUpgrades.Add(upgradeName);
                upgradePurchased = true;
            }
            else
            {
                Debug.Log("Not enough data.");
            }
        }
    }

}
