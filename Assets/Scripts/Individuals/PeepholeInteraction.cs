
using UnityEngine;

public class PeepholeInteraction : MonoBehaviour
{
    [SerializeField] private ViewManager viewManager;

    [Header("Views")]
    [SerializeField] private InteractionView normalView;
    [SerializeField] private InteractionView endingView;

    [Header("Conditions")]
    [SerializeField] private StoryCondition upload100Condition;
    [SerializeField] private StoryCondition finalExitAttemptCondition;

    [Header("Ending")]
    [SerializeField] private PeepholeEnding peepholeEnding;

    public void LookThrough()
    {
        bool uploadComplete = upload100Condition != null &&
                              upload100Condition.conditionMet;

        bool attemptedExit = finalExitAttemptCondition != null &&
                             finalExitAttemptCondition.conditionMet;

        // Before upload reaches 100%
        if (!uploadComplete)
        {
            viewManager.ChangeView(normalView);
            return;
        }

        // After upload: always look into the dark ending view
        viewManager.ChangeView(endingView);

        // Only begin the monster sequence after trying the door
        if (attemptedExit)
        {
            peepholeEnding?.TryStartEnding();
        }
    }
}
