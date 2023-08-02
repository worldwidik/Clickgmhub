using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    public ClickerMain clickerMain;
    public LogsPassiveUpgrade logsPassiveUpgrade;

    public int initialUpgradeCost = 10; // ��������� ���� ��������
    public float upgradeCostMultiplier = 1.5f; // ��������� ��� ���������� ���� �������� ����� ������ �������
    public int logsIncreaseAmount = 1; // ��������� ���������� ����������� ������
    public float logsIncreaseMultiplier = 2f; // ��������� ��� ���������� ���������� ����������� ������ ����� ������ �������

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
        upgradeCostText.text = "���������: " + currentUpgradeCost.ToString();
    }

    public void PurchaseUpgrade()
    {
        if (clickerMain.money >= currentUpgradeCost)
        {
            clickerMain.money -= currentUpgradeCost;
            clickerMain.UpdateMoneyText();

            logsPassiveUpgrade.passiveLogsIncreaseAmount += currentLogsIncreaseAmount; // ����������� ���������� ����������� ������
            logsPassiveUpgrade.StartPassiveUpgrade(); // �������� ��������� ���������

            // ����������� ���� �������� � ���������� ����������� ������ ��� ��������� �������
            currentUpgradeCost = Mathf.RoundToInt(currentUpgradeCost * upgradeCostMultiplier);
            currentLogsIncreaseAmount = Mathf.RoundToInt(currentLogsIncreaseAmount * logsIncreaseMultiplier);

            // ��������� ����� �� ������ � ����� ����� ��������
            UpdateUpgradeCostText();
        }
    }
}


