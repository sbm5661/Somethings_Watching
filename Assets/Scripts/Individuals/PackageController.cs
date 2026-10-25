using UnityEngine;
using UnityEngine.Events;

public class PackageController : MonoBehaviour
{
    //[SerializeField] private GameObject closedBox;
    //[SerializeField] private GameObject openedBox;

    [SerializeField] private UnityEvent onPackageOpened;

    private bool isOpened = false;

    public void OpenPackage()
    {
        if (isOpened)
            return;

        isOpened = true;


        //closedBox.SetActive(false);
        //openedBox.SetActive(true);

        onPackageOpened?.Invoke();
    }
}