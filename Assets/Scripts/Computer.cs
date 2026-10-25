using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Computer : MonoBehaviour
{
    [SerializeField] Image progressBar;
    [SerializeField] TextMeshProUGUI UploadingText;
    [SerializeField] StoryCondition uploadCondition;
    public void ScreenClicked()
    {
        UploadingText.gameObject.SetActive(true);
        SetLoadingBarAmount(0.08f, 3f);
    }

    public void SetLoadingBarAmount(float amount, float duration)
    {
        amount = Mathf.Clamp(amount, 0f, 1f);
        progressBar.DOFillAmount(amount, duration).SetEase(Ease.Linear).OnComplete(() => {
            uploadCondition.SetCondition(true);
        });
    }
}
