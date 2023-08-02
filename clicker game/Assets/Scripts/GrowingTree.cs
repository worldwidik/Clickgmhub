using UnityEngine;
using UnityEngine.UI;

public class GrowingTree : MonoBehaviour
{
    public Image treeImage;
    public Sprite[] growthStages;
    public int clicksForNextStage = 10;

    private int currentStageIndex = 0;
    private int clickCount = 0;

    private void Start()
    {
        UpdateTreeImage();
    }

    public void OnClick()
    {
        clickCount++;
        if (clickCount >= clicksForNextStage)
        {
            clickCount = 0;
            currentStageIndex = (currentStageIndex + 1) % growthStages.Length;
            UpdateTreeImage();
        }
    }

    private void UpdateTreeImage()
    {
        treeImage.sprite = growthStages[currentStageIndex];
    }
}

