using UnityEngine;

public class StoryCondition : MonoBehaviour
{
    public bool conditionMet { get; private set; } = false;

    public void SetCondition(bool condition)
    {
        Debug.Log($"Story condition {gameObject.name} set");
        conditionMet = condition;
    }
}
