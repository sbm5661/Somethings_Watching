using UnityEngine;

public class ChairController : MonoBehaviour
{
    [SerializeField] private Transform originalPosition;

    public void RestorePosition()
    {
        transform.SetPositionAndRotation(
            originalPosition.position,
            originalPosition.rotation
        );
    }
}