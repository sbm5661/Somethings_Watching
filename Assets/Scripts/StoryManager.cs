using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public static StoryManager Instance { get; private set; }

    [Header("Story Graph")]
    [SerializeField] private List<StoryFlag> storyFlags = new List<StoryFlag>();

    private StoryFlag currentFlag;

    private void Start()
    {
        for(int i=0;i<storyFlags.Count;i++)
        {
            if (i != storyFlags.Count - 1) storyFlags[i].nextFlag = storyFlags[i + 1];
            else storyFlags[i].nextFlag = null;
        }
        currentFlag = storyFlags[0];
        Debug.Log($"Starting Flag: {currentFlag.flagName}");
    }

    private void Update()
    {
        if (currentFlag != null)
        {
            if (currentFlag.conditionsMet())
            {
                AdvanceCurrentFlag();
            }
        }
    }

    private void AdvanceCurrentFlag()
    {
        currentFlag = currentFlag.nextFlag;
        Debug.Log($"New Flag: {currentFlag.flagName}");
        currentFlag.onFlagSet?.Invoke();
    }
}