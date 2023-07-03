using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreTabController : MonoBehaviour
{
    public RectTransform storePanel;
    public float slideSpeed = 1000f;
    public bool isExpanded = false;

    private Vector2 expandedPosition;
    private Vector2 collapsedPosition;

    private void Start()
    {
        expandedPosition = storePanel.anchoredPosition;
        collapsedPosition = new Vector2(-storePanel.rect.width, expandedPosition.y);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isExpanded)
                CollapseStorePanel();
            else
                ExpandStorePanel();
        }
    }

    private void ExpandStorePanel()
    {
        isExpanded = true;
    }

    private void CollapseStorePanel()
    {
        isExpanded = false;
    }

    private void FixedUpdate()
    {
        Vector2 targetPosition = isExpanded ? expandedPosition : collapsedPosition;
        storePanel.anchoredPosition = Vector2.Lerp(storePanel.anchoredPosition, targetPosition, slideSpeed * Time.fixedDeltaTime);
    }
}

