﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 
using UnityEngine.UI;

public class textChange : MonoBehaviour
{
    public Text theText;

    void Start()
    {
        theText = GetComponentInChildren<Text>();
    }

    public void OnPointerEnter()
    {
        theText.color = Color.red; //Or however you do your color
        print("on");
    }
 
    public void OnPointerExit(PointerEventData eventData)
    {
        theText.color = Color.white; //Or however you do your color
        print("off");
    }
}
