using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UpgradePurchaseButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{

    public Upgrade upgrade;
    public Image image;

    public void Start()
    {
        image = GetComponent<Image>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        upgrade.PurchaseUpgrade();
        if (upgrade.upgradePurchased)
        {
            image.color = Color.red;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!upgrade.upgradePurchased)
        {
            image.color = Color.blue;
        }
        else image.color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!upgrade.upgradePurchased)
        {
            image.color = Color.green;
        }
        else image.color = Color.red;
    }
}
