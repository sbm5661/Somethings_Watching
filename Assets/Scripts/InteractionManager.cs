using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private Camera activeCamera;

    void Update()
    {
        if (!Input.GetMouseButtonDown(0))
            return;

        Ray ray = activeCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            IInteractable target =
                hit.collider.GetComponentInParent<IInteractable>();

            target?.Interact();
        }
    }
}