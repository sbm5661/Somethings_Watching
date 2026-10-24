
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    [Header("View Settings")]
    [SerializeField] private InteractionView initialView;
    [SerializeField] private InteractionView[] allViews;
    [SerializeField] private float moveDuration = 1f;

    private InteractionView currentView;
    private Stack<InteractionView> viewHistory = new();

    private bool isMoving = false;

    private void Start()
    {
        currentView = initialView;

        // Disable every view's interactions.
        SetAllInteractions(false);

        // Enable only the starting view.
        if (currentView != null)
        {
            currentView.SetInteractionsActive(true);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoBack();
        }
    }
    public void ChangeView(InteractionView nextView)
    {
        if (isMoving || nextView == null ||
            nextView == currentView ||
            nextView.CameraTarget == null ||
            CameraController.Instance == null)
            return;

        if (currentView != null)
            viewHistory.Push(currentView);

        StartCoroutine(TransitionTo(nextView));
    }

    public void GoBack()
    {
        if (isMoving || viewHistory.Count == 0 ||
            CameraController.Instance == null)
            return;

        InteractionView previousView = viewHistory.Peek();

        if (previousView == null ||
            previousView.CameraTarget == null)
            return;

        viewHistory.Pop();
        StartCoroutine(TransitionTo(previousView));
    }
    private IEnumerator TransitionTo(InteractionView nextView)
    {
        if (nextView.CameraTarget == null ||
            CameraController.Instance == null)
        {
            Debug.LogWarning("Camera target or controller is missing.");
            yield break;
        }

        isMoving = true;

        SetAllInteractions(false);

        Transform target = nextView.CameraTarget;

        CameraController.Instance.MoveCameraSmooth(
            target.position,
            target.eulerAngles,
            moveDuration
        );

        yield return new WaitForSeconds(moveDuration);

        currentView = nextView;
        currentView.SetInteractionsActive(true);

        isMoving = false;
    }

    private void SetAllInteractions(bool active)
    {
        foreach (InteractionView view in allViews)
        {
            if (view != null)
            {
                view.SetInteractionsActive(active);
            }
        }
    }
}
