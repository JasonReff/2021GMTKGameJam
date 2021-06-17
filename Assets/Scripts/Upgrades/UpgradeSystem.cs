using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    public static UpgradeSystem current;

    public GameObject UpgradePanel;
    public GameObject upgradePrefab;
    public TextMeshProUGUI combatDataText;
    public TextMeshProUGUI dataTextbox;
    public TextMeshProUGUI ownedUpgradesTextbox;
    public TextMeshProUGUI livesTextbox;
    public int currentData = 0;
    public int lifeCost = 3;
    public TextMeshProUGUI lifeCostTextbox;

    public float bulletForceMultiplier;
    public float movementSpeedMultiplier;
    public float bulletRangeMultiplier;
    public float fireRateMultiplier;
    public float lifespanMultiplier;

    public List<string> potentialUpgrades;
    public List<string> ownedUpgrades = new List<string> { };

    private void Start()
    {
        current = this;
    }

    private void Update()
    {
        dataTextbox.text = $"Data: {currentData}";
        combatDataText.text = $"Data: {currentData}";
        string ownedUpgradesString = string.Join(" , ", ownedUpgrades);
        ownedUpgradesTextbox.text = $"Owned Upgrades: {ownedUpgradesString}";

    }

    public void GetLives()
    {
        livesTextbox.text = $"Lives: {PlayerCharacter.Glitch.lives}";
        lifeCostTextbox.text = lifeCost.ToString();
    }

    public void PurchaseLife()
    {
        if (currentData >= lifeCost)
        {
            PlayerCharacter.Glitch.lives++;
            livesTextbox.text = $"Lives: {PlayerCharacter.Glitch.lives}";
            currentData -= lifeCost;
            lifeCost++;
            lifeCostTextbox.text = lifeCost.ToString();
            Debug.Log("Life purchased.");
        }
        else
        {
            Debug.Log("Not enough data to purchase life.");
        }
    }

    public void GetUpgrades()
    {
        potentialUpgrades = new List<string> { "BulletForceUpgrade", "MovementSpeedUpgrade", "BulletRangeUpgrade",
    "LifespanUpgrade", "FireRateUpgrade"};
        List<string> displayedUpgrades = new List<string> { };
        for (int i = 1; i <= 3; i++)
        {
            string upgradeName = PullUpgradeFromList();
            displayedUpgrades.Add(upgradeName);
        }
        foreach(string upgradeName in displayedUpgrades)
        {
            GameObject upgradeObject = Instantiate(upgradePrefab, UpgradePanel.transform);
            upgradeObject = GetRandomUpgrade(upgradeObject, upgradeName);
            upgradeObject.GetComponent<Upgrade>().GetText();
        }
    }

    public void DeleteUpgrades()
    {
        for (int i = 1; i <= UpgradePanel.transform.childCount; i++)
        {
            GameObject upgrade = UpgradePanel.transform.GetChild(0).gameObject;
            Destroy(upgrade);
        }
    }

    public GameObject GetRandomUpgrade(GameObject upgradeObject, string upgradeName)
    {
        Type t = Type.GetType(upgradeName);
        upgradeObject.AddComponent(t);
        return upgradeObject;
    }

    public string PullUpgradeFromList()
    {
        int upgradeNumber = UnityEngine.Random.Range(0, potentialUpgrades.Count - 1);
        string upgradeName = potentialUpgrades[upgradeNumber];
        potentialUpgrades.Remove(upgradeName);
        return upgradeName;
    }

}
