using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogsToMoneyConverter : MonoBehaviour
{
    public ClickerMain clickerMain;
    public TMPro.TextMeshProUGUI moneyText;
    public GameObject inputPanel;
    public TMPro.TMP_InputField inputField;
    public Button convertButton;
    public GameObject insufficientLogsText;


    private int maxLogsToConvert;

    public void Start()
    {
        convertButton.onClick.AddListener(ConvertLogsToMoney);
    }

    public void ConvertLogsToMoney()
    {
        int logsToConvert;
        if (int.TryParse(inputField.text, out logsToConvert))
        {
            if (logsToConvert <= clickerMain.logs)
            {
                int moneyGained = logsToConvert; // You can apply conversion rates here if needed
                clickerMain.logs -= logsToConvert;
                clickerMain.money += moneyGained;
                clickerMain.UpdateMoneyText();
                clickerMain.UpdatelogsText();
            }
            else
            {
                ShowInsufficientLogsText();
            }
        }
        else
        {
            Debug.Log("Invalid input. Please enter a valid number.");
        }
    }

    public void ShowInsufficientLogsText()
    {
        StartCoroutine(ShowInsufficientLogsTextCoroutine());
    }

    private IEnumerator ShowInsufficientLogsTextCoroutine()
    {
        insufficientLogsText.SetActive(true);
        yield return new WaitForSeconds(2f);
        insufficientLogsText.SetActive(false);
    }

    public void OpenInputPanel()
    {
        inputPanel.SetActive(true);
        maxLogsToConvert = clickerMain.logs;
        inputField.text = "0";
        inputField.characterValidation = TMPro.TMP_InputField.CharacterValidation.Integer;
        inputField.contentType = TMPro.TMP_InputField.ContentType.IntegerNumber;
        inputField.Select();
        inputField.ActivateInputField();
    }
    public void ToggleExchangePanel()
    {
        inputPanel.SetActive(!inputPanel.activeSelf); // Открыть/закрыть панель ввода
        if (inputPanel.activeSelf)
        {
            maxLogsToConvert = clickerMain.logs;
            inputField.text = "0";
            inputField.characterValidation = TMPro.TMP_InputField.CharacterValidation.Integer;
            inputField.contentType = TMPro.TMP_InputField.ContentType.IntegerNumber;
            inputField.Select();
            inputField.ActivateInputField();
        }
    }
}


