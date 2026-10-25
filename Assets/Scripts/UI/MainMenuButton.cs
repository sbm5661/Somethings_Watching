using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public UnityEvent onPlay;
    public void Play()
    {
        onPlay?.Invoke();
        this.gameObject.SetActive(false);
    }
}
