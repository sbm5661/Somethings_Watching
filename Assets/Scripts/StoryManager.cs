using System;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    [SerializeField] private List<string> storyFlags; // List of story flags to be set in the inspector
    private Dictionary<string, bool> storyFlagsDict = new Dictionary<string, bool>();

    public static StoryManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        // Initialize the story flags dictionary with the flags from the inspector
        foreach (string flag in storyFlags)
        {
            if (!storyFlagsDict.ContainsKey(flag))
            {
                storyFlagsDict.Add(flag, false);
            }
        }
    }

    public void SetStoryFlag(string flag, bool value)
    {
        if (storyFlagsDict.ContainsKey(flag))
        {
            storyFlagsDict[flag] = value;
            TriggerStoryEvent();
        }
        else
        {
            Debug.LogWarning($"Story flag '{flag}' does not exist.");
        }
    }

    private void TriggerStoryEvent()
    {
        switch(storyFlagsDict)
        {
            case var flags when flags.ContainsKey("FlagA") && flags["FlagA"]:
                Debug.Log("Event triggered for FlagA");
                break;
            case var flags when flags.ContainsKey("FlagB") && flags["FlagB"]:
                Debug.Log("Event triggered for FlagB");
                break;
            default:
                Debug.Log("No story event triggered.");
                break;
        }
    }
}
