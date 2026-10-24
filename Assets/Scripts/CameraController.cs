using DG.Tweening;
using DG.Tweening.Core.Easing;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 previousPosition { get; private set; }
    public Vector3 previousRotation { get; private set; }

    public static CameraController Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        previousPosition = transform.position;
        previousRotation = transform.eulerAngles;
    }

    public void MoveCamera(Vector3 targetPosition, Vector3 targetRotation, float duration)
    {
        previousPosition = transform.position;
        previousRotation = transform.eulerAngles;

        transform.DORotate(targetRotation, duration);
        transform.DOMove(targetPosition, duration);
    }
    public void ShakeCamera(float duration, float strength)
    {
        transform.DOShakePosition(duration, strength);
    }
}
