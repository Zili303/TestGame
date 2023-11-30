using UnityEngine;
using TMPro;

public abstract class UIElement : MonoBehaviour
{
    protected Player player;
    protected TMP_Text text;

    public virtual void SetupListener(Player playerComponent)
    {
        player = playerComponent;
        text = GetComponent<TMP_Text>();
    }

    public abstract void DisableListener();

    public virtual void UpdateText(int value)
    {

    }

    public virtual void UpdateText(float value)
    {

    }
}
