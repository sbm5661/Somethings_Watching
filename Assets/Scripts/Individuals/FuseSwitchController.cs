using UnityEngine;
using UnityEngine.Events;

public class FuseSwitchController : MonoBehaviour
{
    [SerializeField] private UnityEvent onPowerRestored;

    private bool hasBeenActivated = false;

    public void ActivateSwitch()
    {
        if (hasBeenActivated)
            return;

        hasBeenActivated = true;

        Debug.Log("Fuse switch activated!");
        onPowerRestored?.Invoke();
    }
}