using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComputerDocument : MonoBehaviour
{
    [TextArea][SerializeField] List<string> documentEntries = new List<string>();
    [SerializeField] private TextMeshProUGUI documentText;
    [SerializeField] private Image BackButton;
    [SerializeField] private Image NextButton;
    [SerializeField] private Image ConfirmButton;
    [SerializeField] private TextMeshProUGUI ConfirmButtonText;
    [SerializeField] private Color enabledColor;
    [SerializeField] private Color disabledColor;

    int currentEntry = 0;
    int currentPage = 0;
    bool canConfirm = false;

    List<string> pageTexts = new List<string>();

    public void DisplayEntry()
    {
        pageTexts = documentEntries[currentEntry].Split(';').ToList();
        currentPage = 0;
        canConfirm = false;
        ConfirmButton.color = disabledColor;
        ConfirmButtonText.text = "Review Document";
        BackButton.color = disabledColor;
        NextButton.color = enabledColor;
        documentText.text = pageTexts[currentPage];
    }

    public void NextPage()
    {
        if (currentPage >= pageTexts.Count - 1) return;
        currentPage += 1;
        documentText.text = pageTexts[currentPage];
        updateButtons();
    }
    public void BackPage()
    {
        if (currentPage <= 0) return;
        currentPage -= 1;
        documentText.text = pageTexts[currentPage];
        updateButtons();
    }

    public void ConfirmDocument()
    {
        if (!canConfirm) return;
        currentEntry += 1;
        Debug.Log("confirmed document");
    }

    private void updateButtons()
    {
        if (currentPage >= pageTexts.Count - 1)
        {
            ConfirmButton.color = enabledColor;
            ConfirmButtonText.text = "Confirm Upload";
            NextButton.color = disabledColor;
            canConfirm = true;
        }
        else
            NextButton.color = enabledColor;

        if (currentPage <= 0)
            BackButton.color = disabledColor;
        else
            BackButton.color = enabledColor;
    }
}
