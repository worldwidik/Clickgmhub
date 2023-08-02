using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    public ClickerMain clickerMain;
    public LogsPassiveUpgrade logsPassiveUpgrade;

    public int initialUpgradeCost = 10; // Начальная цена апгрейда
    public float upgradeCostMultiplier = 1.5f; // Множитель для увеличения цены апгрейда после каждой покупки
    public int logsIncreaseAmount = 1; // Начальное количество получаемого дерева
    public float logsIncreaseMultiplier = 2f; // Множитель для увеличения количества получаемого дерева после каждой покупки

    public TextMeshProUGUI upgradeCostText;
    public Button upgradeButton;

    private int currentUpgradeCost;
    private int currentLogsIncreaseAmount;

    private void Start()
    {
        currentUpgradeCost = initialUpgradeCost;
        currentLogsIncreaseAmount = logsIncreaseAmount;

        upgradeButton.onClick.AddListener(PurchaseUpgrade);
        UpdateUpgradeCostText();
    }

    private void UpdateUpgradeCostText()
    {
        upgradeCostText.text = "Улучшение: " + currentUpgradeCost.ToString();
    }

    public void PurchaseUpgrade()
    {
        if (clickerMain.money >= currentUpgradeCost)
        {
            clickerMain.money -= currentUpgradeCost;
            clickerMain.UpdateMoneyText();

            logsPassiveUpgrade.passiveLogsIncreaseAmount += currentLogsIncreaseAmount; // Увеличиваем количество получаемого дерева
            logsPassiveUpgrade.StartPassiveUpgrade(); // Включаем пассивное улучшение

            // Увеличиваем цену апгрейда и количество получаемого дерева для следующей покупки
            currentUpgradeCost = Mathf.RoundToInt(currentUpgradeCost * upgradeCostMultiplier);
            currentLogsIncreaseAmount = Mathf.RoundToInt(currentLogsIncreaseAmount * logsIncreaseMultiplier);

            // Обновляем текст на кнопке с новой ценой апгрейда
            UpdateUpgradeCostText();
        }
    }
}


