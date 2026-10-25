using UnityEngine;
using TMPro;
using System.Collections;

public class HintUI : MonoBehaviour
{
    [SerializeField] private GameObject hintPanel;
    [SerializeField] private TextMeshProUGUI hintText;

    private Coroutine hideRoutine;

    private void Start()
    {
        hintPanel.SetActive(false);
    }

    public void ShowHint(string message)
    {
        if (hideRoutine != null)
            StopCoroutine(hideRoutine);

        hintText.text = message;
        hintPanel.SetActive(true);

        hideRoutine = StartCoroutine(HideAfterDelay());
    }

    private IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(3f);

        hintPanel.SetActive(false);
        hideRoutine = null;
    }
}