using UnityEngine;

public class DoorLock : MonoBehaviour, IInteractable
{
    [SerializeField] private bool isLocked;

    public bool IsLocked => isLocked;

    public void Interact()
    {
        isLocked = !isLocked;

        if (isLocked)
        {
            Debug.Log("Door locked");
        }
        else
        {
            Debug.Log("Door unlocked");
        }

        // TODO: Play animation and sound
    }
}