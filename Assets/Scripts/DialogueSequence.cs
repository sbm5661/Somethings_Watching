using System.Collections.Generic;

[System.Serializable]
public class DialogueSequence
{
    public string dialogueTitle;
    public List<DialogueLine> sequence = new List<DialogueLine>();
}
