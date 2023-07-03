using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerMain : MonoBehaviour
{
    public int money = 0;
    public int clickValue = 1;
    public TMPro.TextMeshProUGUI moneyText;

    private void Start()
    {
        UpdateMoneyText();
    }

    public void OnClick()
    {
        money += clickValue;
        UpdateMoneyText();
    }
    private void UpdateMoneyText()
    {
        moneyText.text = money.ToString();
    }
}


