using UnityEngine;

public class SecureRoomInteraction : MonoBehaviour
{
    [SerializeField] private ViewManager viewManager;
    [SerializeField] private InteractionView computerView;

    [Header("Requirements")]
    [SerializeField] private StoryCondition doorLocked;
    [SerializeField] private StoryCondition windowLocked;

    [Header("Feedback")]
    [SerializeField] private HintUI hintUI;

    public void TryEnterComputer()
    {
        if (!doorLocked.conditionMet || !windowLocked.conditionMet)
        {
            hintUI.ShowHint("You should secure the place first.");
            return;
        }

        viewManager.ChangeView(computerView);
    }
}