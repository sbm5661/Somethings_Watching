using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PeepholeEnding : MonoBehaviour
{
    [Header("Ending Requirement")]
    [SerializeField] private StoryCondition finalExitAttemptCondition;

    [Header("Ending Visual")]
    [SerializeField] private ViewManager viewManager;
    [SerializeField] private GameObject redEyeVisual;
    [SerializeField] private float revealDelay = 4f;

    [Header("Scene Transition")]
    [SerializeField] private string creditsSceneName = "Credits&EndingScene";
    [SerializeField] private float sceneDelay = 2f;

    private bool endingStarted = false;

    private void Start()
    {
        if (redEyeVisual != null)
            redEyeVisual.SetActive(false);
    }

    public void TryStartEnding()
    {
        if (endingStarted ||
            finalExitAttemptCondition == null ||
            !finalExitAttemptCondition.conditionMet)
            return;

        endingStarted = true;

        // Once the monster sequence begins, ESC is disabled
        viewManager?.SetExitLocked(true);

        StartCoroutine(EndingSequence());
    }

    private IEnumerator EndingSequence()
    {
        // Allow ViewManager to finish moving to the peephole
        yield return new WaitForSeconds(1f);

        if (redEyeVisual != null)
            redEyeVisual.SetActive(true);

        // Let the player observe the red eye
        yield return new WaitForSeconds(revealDelay);

        // Additional time for fade-out or other effects
        yield return new WaitForSeconds(sceneDelay);

        SceneManager.LoadScene(creditsSceneName);
    }
}