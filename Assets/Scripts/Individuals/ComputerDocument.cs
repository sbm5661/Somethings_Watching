using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ComputerDocument : MonoBehaviour
{
    [TextArea][SerializeField] List<string> documentEntries = new List<string>();
    [SerializeField] private UnityEvent onDocumentConfirmed;
    [SerializeField] private TextMeshProUGUI documentText;
    [SerializeField] private Image BackButton;
    [SerializeField] private Image NextButton;
    [SerializeField] private Image ConfirmButton;
    [SerializeField] private TextMeshProUGUI ConfirmButtonText;
    [SerializeField] private Color enabledColor;
    [SerializeField] private Color disabledColor;

    [Header("Altered Document")]
    [TextArea(3, 10)]
    [SerializeField] private string alteredDocument;
    private bool showingAlteredDocument = false;

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
        documentText.text = pageTexts[currentPage];

        updateButtons();
    }

    public void NextPage()
    {
        Debug.Log($"Next clicked! Page: {currentPage}, Total: {pageTexts.Count}");
        if (currentPage >= pageTexts.Count - 1) return;
        currentPage += 1;
        documentText.text = pageTexts[currentPage];
        updateButtons();
    }
    public void BackPage()
    {
        Debug.Log($"Back clicked! Page: {currentPage}, Total: {pageTexts.Count}");
        if (currentPage <= 0) return;
        currentPage -= 1;
        documentText.text = pageTexts[currentPage];
        updateButtons();
    }

    public void ConfirmDocument()
    {
        if (!canConfirm)
            return;

        if (showingAlteredDocument)
        {
            showingAlteredDocument = false;
            canConfirm = false;

            Debug.Log("Altered document confirmed");
            onDocumentConfirmed?.Invoke();
            return;
        }

        currentEntry++;
        Debug.Log("Confirmed document");

        if (currentEntry < documentEntries.Count)
        {
            // Display the next document
            DisplayEntry();
        }
        else
        {
            // All documents have been reviewed
            Debug.Log("All documents confirmed!");
            onDocumentConfirmed?.Invoke();
        }
    }

    private void updateButtons()
    {
        if (currentPage >= pageTexts.Count - 1)
        {
            NextButton.color = disabledColor;
            canConfirm = true;
        }
        else
            NextButton.color = enabledColor;

        ConfirmButton.color = canConfirm ? enabledColor : disabledColor;

        ConfirmButtonText.text = canConfirm
            ? (showingAlteredDocument || currentEntry == documentEntries.Count - 1
                ? "Confirm Upload"
                : "Next Document")
            : "Review Document";

        BackButton.color = currentPage <= 0
            ? disabledColor
            : enabledColor;
    }

    public void DisplayAlteredEntry()
    {
        showingAlteredDocument = true;

        pageTexts = alteredDocument.Split(';').ToList();
        currentPage = 0;
        canConfirm = false;

        documentText.text = pageTexts[currentPage];

        updateButtons();
    }
}
