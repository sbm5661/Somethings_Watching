using UnityEngine;

public class StoryCondition : MonoBehaviour
{
    public bool conditionMet { get; private set; } = false;

    public void SetCondition(bool condition)
    {
        conditionMet = condition;
    }
}
