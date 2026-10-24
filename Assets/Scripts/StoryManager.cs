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
            TriggerStoryEvent(flag);
        }
        else
        {
            Debug.LogWarning($"Story flag '{flag}' does not exist.");
        }
    }

    private void TriggerStoryEvent(string flag)
    {
        if (flag == "door locked" || flag == "window locked")
        {
            if (isFlagSet("door locked") && isFlagSet("window locked"))
            {
                Debug.Log("Event triggered for both door and window locked");
                DialogueManager.Instance?.EnqueueDialogue(new string[]{"Both door and window locked.", "Everything is secure."});
            }
        }
    }

    private bool isFlagSet(string flag)
    {
        return storyFlagsDict.ContainsKey(flag) && storyFlagsDict[flag];
    }

}
