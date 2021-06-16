using JetBrains.Annotations;
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
    public TextMeshProUGUI dataTextbox;
    public int currentData = 0;

    public float bulletForceMultiplier;
    public float movementSpeedMultiplier;
    public float bulletRangeMultiplier;
    public float fireRateMultiplier;
    public float lifespanMultiplier;

    public List<string> potentialUpgrades;

    private void Start()
    {
        current = this;
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
