using System.Collections;
using System.Collections.Generic;
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

    public void Awake()
    {
        nameTextbox = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        descriptionTextbox = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        transform.GetChild(2).GetComponent<UpgradePurchaseButton>().upgrade = this;
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
        if (UpgradeSystem.current.currentData >= cost)
        {
            UpgradeEffect();
            Debug.Log("Upgrade Purchased.");
        }
        else
        {
            Debug.Log("Not enough data.");
        }
    }

}
