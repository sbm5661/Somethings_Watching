using UnityEngine;

public class ExteriorDoorInteraction : MonoBehaviour
{
    [SerializeField] private ViewManager viewManager;
    [SerializeField] private InteractionView outsideView;
    [SerializeField] private StoryCondition powerOutageCondition;
    [SerializeField] private HintUI hintUI;

    public void TryExit()
    {
        if (powerOutageCondition == null ||
            !powerOutageCondition.conditionMet)
        {
            hintUI?.ShowHint("You don't need to go outside yet.");
            return;
        }

        viewManager.ChangeView(outsideView);
    }
}