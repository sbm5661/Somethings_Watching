using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class StoryFlag
{
    public string flagName;
    [HideInInspector] public StoryFlag nextFlag;
    public UnityEvent onFlagSet;
    [SerializeField] private List<StoryCondition> conditions = new List<StoryCondition>();

    public bool conditionsMet()
    {
        if (nextFlag == null) return false;
        foreach(StoryCondition condition in conditions)
        {
            if (!condition.conditionMet) return false;
        }
        return true;
    }

    public void setNextFlag(StoryFlag nextFlag)
    {
        this.nextFlag = nextFlag;
    }
}