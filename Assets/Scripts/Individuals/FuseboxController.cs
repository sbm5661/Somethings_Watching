using UnityEngine;
using DG.Tweening;

public class FuseboxController : MonoBehaviour
{
    [SerializeField] private Transform doorPivot;
    [SerializeField] private Vector3 openRotation = new Vector3(0, 100, 0);
    [SerializeField] private float duration = 0.5f;

    private Vector3 closedRotation;
    private bool isOpen = false;

    private void Awake()
    {
        closedRotation = doorPivot.localEulerAngles;
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;

        doorPivot.DOKill();

        Vector3 targetRotation = isOpen
            ? closedRotation + openRotation
            : closedRotation;

        doorPivot.DOLocalRotate(targetRotation, duration);
    }
}