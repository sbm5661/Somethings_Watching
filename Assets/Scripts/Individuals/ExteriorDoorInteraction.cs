
using UnityEngine;
using DG.Tweening;

public class ExteriorDoorInteraction : MonoBehaviour
{
    [Header("Navigation")]
    [SerializeField] private ViewManager viewManager;
    [SerializeField] private InteractionView outsideView;

    [Header("Story Conditions")]
    [SerializeField] private StoryCondition powerOutageCondition;
    [SerializeField] private StoryCondition finalExitAttemptCondition;
    [SerializeField] private string finalEscapeFlag = "Leaving";

    [Header("Inventory")]
    [SerializeField] private string requiredItemID = "PlaneTicket";

    [Header("Feedback")]
    [SerializeField] private HintUI hintUI;
    [SerializeField] private DoorLock doorLock;

    [Header("Final Exit Sequence")]
    [SerializeField] private float messageInterval = 3f;

    private int messageIndex = 0;
    private float nextMessageTime = 0f;

    private readonly string[] exitMessages =
    {
        "It won't open.",
        "There's no way to unlock it.",
        "You are trapped in here.",
        "You cannot leave."
    };

    public void TryExit()
    {
        // Final escape stage
        if ((StoryManager.Instance != null &&
             StoryManager.Instance.IsCurrentFlag(finalEscapeFlag)) ||
            (finalExitAttemptCondition != null &&
             finalExitAttemptCondition.conditionMet))
        {
            bool hasTicket = InventoryManager.Instance != null &&
                             InventoryManager.Instance.HasItem(requiredItemID);

            if (!hasTicket)
            {
                hintUI?.ShowHint("I should grab my plane ticket first.");
                return;
            }

            doorLock?.ShakeDoor();

            // Unlock the red eye event after the first failed exit attempt
            finalExitAttemptCondition?.SetCondition(true);

            // Prevent rapid clicking from skipping messages
            if (Time.time < nextMessageTime)
                return;

            hintUI?.ShowHint(exitMessages[messageIndex]);

            if (messageIndex < exitMessages.Length - 1)
            {
                messageIndex++;
            }
            else
            {
                // Ready for the peephole event
                finalExitAttemptCondition?.SetCondition(true);
            }

            nextMessageTime = Time.time + messageInterval;
            return;
        }

        // Normal exterior door behavior
        if (powerOutageCondition == null ||
            !powerOutageCondition.conditionMet)
        {
            hintUI?.ShowHint("You don't need to go outside yet.");
            return;
        }

        viewManager.ChangeView(outsideView);
    }
}
