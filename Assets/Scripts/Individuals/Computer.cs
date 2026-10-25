using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Computer : MonoBehaviour
{

    [SerializeField] Image progressBar;
    [SerializeField] TextMeshProUGUI UploadingText;
    [SerializeField] StoryCondition uploadCondition;
    [SerializeField] private StoryCondition upload50Condition;
    [SerializeField] private StoryCondition upload80Condition;
    [SerializeField] private StoryCondition upload100Condition;
    private int uploadStage = 0;
    private bool isUploading = false;

    private Dictionary<int, float> uploadStages = new Dictionary<int, float>
    {
        [0] = 0.08f,
        [1] = 0.5f,
        [2] = 0.8f,
        [3] = 1f,
    };
    private float[] uploadDurations = {3f, 10f, 3f, 3f};

    public void ScreenClicked()
    {
        if (isUploading || uploadStage >= uploadStages.Count)
            return;

        float target = uploadStages[uploadStage];
        float duration = uploadDurations[uploadStage];

        isUploading = true;
        UploadingText.gameObject.SetActive(true);

        SetLoadingBarAmount(target, duration);
    }
    public void SetLoadingBarAmount(float amount, float duration)
    {
        amount = Mathf.Clamp01(amount);

        progressBar.DOFillAmount(amount, duration)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                isUploading = false;
                uploadStage++;

                if (uploadStage == 1)
                    uploadCondition?.SetCondition(true);
                else if (uploadStage == 2)
                    upload50Condition?.SetCondition(true);
                else if (uploadStage == 3)
                    upload80Condition?.SetCondition(true);
                else if (uploadStage == 4)
                    upload100Condition?.SetCondition(true);
            });
    }
}
