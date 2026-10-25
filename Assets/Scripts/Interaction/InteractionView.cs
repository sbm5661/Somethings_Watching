
using UnityEngine;

public class InteractionView : MonoBehaviour
{
    [Header("Interactable Colliders")]
    [SerializeField] private Collider[] colliders;
    public bool isSmooth = true; 
    public Transform CameraTarget => transform;

    public void SetInteractionsActive(bool active)
    {
        foreach (Collider col in colliders)
        {
            if (col != null)
            {
                col.enabled = active;
            }
        }
    }
}
