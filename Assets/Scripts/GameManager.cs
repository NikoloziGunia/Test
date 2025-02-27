using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMP_Text moneyUi;
    public Character character;
    
    public Seller Seller;

    private void Start()
    {
        UpdateMoney();
    }

    public void UpdateMoney()
    {
        moneyUi.text = character.money.ToString();
    }
}
