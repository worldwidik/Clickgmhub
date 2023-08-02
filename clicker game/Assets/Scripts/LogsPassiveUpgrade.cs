using System.Collections;
using UnityEngine;

public class LogsPassiveUpgrade : MonoBehaviour
{
    public ClickerMain clickerMain;
    public int passiveLogsIncreaseAmount = 1;
    public float passiveLogsIncreaseInterval = 1f; // Каждую секунду

    private Coroutine passiveUpgradeCoroutine;
    private bool isUpgradeEnabled = false;

    private void OnEnable()
    {
        if (isUpgradeEnabled)
        {
            StartPassiveUpgrade();
        }
    }

    private void OnDisable()
    {
        StopPassiveUpgrade();
    }

    public void StartPassiveUpgrade()
    {
        if (!isUpgradeEnabled)
        {
            isUpgradeEnabled = true;
            passiveUpgradeCoroutine = StartCoroutine(PassiveUpgradeCoroutine());
        }
    }

    public void StopPassiveUpgrade()
    {
        if (isUpgradeEnabled)
        {
            isUpgradeEnabled = false;
            if (passiveUpgradeCoroutine != null)
            {
                StopCoroutine(passiveUpgradeCoroutine);
                passiveUpgradeCoroutine = null;
            }
        }
    }

    private IEnumerator PassiveUpgradeCoroutine()
    {
        while (true)
        {
            clickerMain.logs += passiveLogsIncreaseAmount;
            clickerMain.UpdatelogsText();
            yield return new WaitForSeconds(passiveLogsIncreaseInterval);
        }
    }
}



