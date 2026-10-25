using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Computer : MonoBehaviour
{

    [SerializeField] Image progressBar;
    [SerializeField] TextMeshProUGUI UploadingText;
    [SerializeField] StoryCondition uploadCondition;
    [SerializeField] private StoryCondition upload50Condition;
    private int uploadStage = 0;
    private bool isUploading = false;
    public void ScreenClicked()
    {
        if (isUploading || uploadStage >= 2)
            return;

        float target = uploadStage == 0 ? 0.08f : 0.50f;
        float duration = uploadStage == 0 ? 3f : 10f;

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
            });
    }
}
