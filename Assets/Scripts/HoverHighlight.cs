using UnityEngine;

public class HoverHighlight : MonoBehaviour
{
    [SerializeField] private Outline highlightEffect;
    private void Awake()
    {
        if (highlightEffect != null)
            highlightEffect.enabled = false;
    }

    public void SetHighlighted(bool highlighted)
    {
        if (highlightEffect != null)
            highlightEffect.enabled = highlighted;
    }
}