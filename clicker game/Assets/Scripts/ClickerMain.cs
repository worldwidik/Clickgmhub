using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickerMain : MonoBehaviour
{
    public int logs = 0;
    public int money = 0; // New variable to store money
    public int clickValue = 1;
    public TMPro.TextMeshProUGUI logsText;
    public TMPro.TextMeshProUGUI moneyText; // Reference to the money text

    public void Start()
    {
        UpdatelogsText();
        UpdateMoneyText(); // Call this method on Start to initialize money text
    }

    public void OnClick()
    {
        logs += clickValue;
        UpdatelogsText();
    }

    public void UpdatelogsText()
    {
        logsText.text = logs.ToString();
    }

    public void UpdateMoneyText() // Method to update the money text
    {
        moneyText.text = money.ToString();
    }
}







