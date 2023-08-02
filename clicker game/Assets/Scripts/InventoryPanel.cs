using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    public GameObject panel;
    private bool isPanelVisible = false;

    private void Start()
    {
        panel.SetActive(isPanelVisible);
    }

    public void TogglePanelinv()
    {
        isPanelVisible = !isPanelVisible;
        panel.SetActive(isPanelVisible);
    }
}
