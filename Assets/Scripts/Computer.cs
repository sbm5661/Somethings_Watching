using UnityEngine;

public class Computer : MonoBehaviour
{
    [SerializeField] private GameObject cameraPosition;
    [SerializeField] private GameObject computerInterface;
    [SerializeField] private Collider computerCollider;

    CameraController cameraController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraController = CameraController.Instance;
        computerInterface.SetActive(false);
    }

    public void EnterComputer()
    {
        CameraController.Instance.MoveCamera(cameraPosition.transform.position, cameraPosition.transform.eulerAngles, 1f);
        computerCollider.enabled = false;
        computerInterface.SetActive(true);
    }

    public void ExitComputer()
    {
        computerCollider.enabled = true;
        computerInterface.SetActive(false);
        // Code to leave computer interface and return to the previous camera view
        cameraController.MoveCamera(cameraController.previousPosition, cameraController.previousRotation, 1f);
    }
}
