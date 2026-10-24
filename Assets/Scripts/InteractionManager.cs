using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private Camera activeCamera;
    private HoverHighlight currentHover;

    void Update()
    {
        HandleHover();

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

    private void HandleHover()
    {
        Ray ray = activeCamera.ScreenPointToRay(Input.mousePosition);

        HoverHighlight nextHover = null;

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            IInteractable target =
                hit.collider.GetComponentInParent<IInteractable>();

            if (target != null)
            {
                nextHover =
                    hit.collider.GetComponentInParent<HoverHighlight>();
            }
        }

        if (currentHover == nextHover)
            return;

        if (currentHover != null)
            currentHover.SetHighlighted(false);

        currentHover = nextHover;

        if (currentHover != null)
            currentHover.SetHighlighted(true);
    }
}