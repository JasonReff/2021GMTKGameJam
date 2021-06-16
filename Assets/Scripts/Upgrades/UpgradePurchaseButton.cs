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
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = Color.blue;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.red;
    }
}
