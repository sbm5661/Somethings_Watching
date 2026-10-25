using UnityEngine;
using System.Collections;

public class PowerOutageController : MonoBehaviour
{
    [SerializeField] private float dialogueDelay = 2f;
    [Header("Room Lights")]
    [SerializeField] private Light[] roomLights;

    [Header("Computer")]
    [SerializeField] private GameObject computerCanvas;

    public void TriggerOutageSequence()
    {
        StartCoroutine(FlickerAndOutage());
    }
    public void TriggerOutage()
    {
        foreach (Light light in roomLights)
        {
            if (light != null)
                light.enabled = false;
        }

        if (computerCanvas != null)
            computerCanvas.SetActive(false);

        Debug.Log("Power outage triggered");
    }
    public void RestorePower()
    {
        foreach (Light light in roomLights)
        {
            if (light != null)
                light.enabled = true;
        }

        if (computerCanvas != null)
            computerCanvas.SetActive(true);

        Debug.Log("Power restored");
    }
    private IEnumerator FlickerAndOutage()
    {
        // First flicker
        TriggerOutage();
        yield return new WaitForSeconds(0.15f);
        RestorePower();
        yield return new WaitForSeconds(0.5f);

        // Rapid flickering
        TriggerOutage();
        yield return new WaitForSeconds(0.1f);
        RestorePower();
        yield return new WaitForSeconds(0.12f);
        TriggerOutage();
        yield return new WaitForSeconds(0.08f);
        RestorePower();
        yield return new WaitForSeconds(0.1f);

        // Final blackout
        TriggerOutage();

        // Silence after blackout
        yield return new WaitForSeconds(dialogueDelay);

        DialogueManager.Instance.ExecuteDialogue();
    }

}