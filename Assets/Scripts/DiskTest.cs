using UnityEngine;

public class DiskTest : MonoBehaviour
{
   public void DiskInserted()
    {
        Debug.Log("Disk inserted! Processing data...");
    }

    public void DiskMissing()
    {
        Debug.Log("Please insert disk.");
    }
}
