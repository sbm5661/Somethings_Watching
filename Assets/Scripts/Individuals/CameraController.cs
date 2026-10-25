using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public Vector3 previousPosition { get; private set; }
    public Vector3 previousRotation { get; private set; }
    [SerializeField] private Image fadeImg;
    [SerializeField] private float fadeTransitionDuration = 0.25f;

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
        if (fadeImg != null)
        {
            fadeImg.DOFade(0f, 2f).SetDelay(1);
        }

    }

    public void MoveCamera(Vector3 targetPosition, Vector3 targetRotation)
    {
        previousPosition = transform.position;
        previousRotation = transform.eulerAngles;

        if (fadeImg == null)
        {
            transform.position = targetPosition;
            transform.eulerAngles = targetRotation;
            return;
        }
        fadeImg.DOFade(1f, 0.5f).OnComplete(() =>
        {
            transform.position = targetPosition;
            transform.eulerAngles = targetRotation;

            fadeImg.DOFade(0f, 0.5f).SetDelay(fadeTransitionDuration);
        });
    }

    public void MoveCameraSmooth(Vector3 targetPosition, Vector3 targetRotation, float duration)
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
