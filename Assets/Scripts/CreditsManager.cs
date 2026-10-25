using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CreditsManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI creditsText;
    [SerializeField] GameObject creditsPanel;
    [SerializeField] [TextArea] string[] creditsContent;
    [SerializeField] float creditDuration = 2f;

    IEnumerator Start()
    {
        creditsPanel.transform.DOShakePosition(duration: (creditDuration*(creditsContent.Length+2))+1, strength: 5f, fadeOut: false);
        yield return new WaitForSeconds(creditDuration+1);
        foreach (string credit in creditsContent)
        {
            creditsText.text = credit;
            yield return new WaitForSeconds(creditDuration);
        }
        creditsPanel.SetActive(false);
        yield return new WaitForSeconds(creditDuration/2);
        Camera.main.transform.DOMoveZ(-12.5f, 5f).SetEase(Ease.Linear);
        yield return new WaitForEndOfFrame();
    }
}
