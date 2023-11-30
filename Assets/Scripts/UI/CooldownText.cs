using UnityEngine;
using TMPro;

public class CooldownText : UIElement
{
    [SerializeField] private Weapon weapon;

    private void OnDisable() 
    {
        DisableListener();
    }

    public override void SetupListener(Player player)
    {
        text = GetComponent<TMP_Text>();
        weapon.OnCooldownChange += UpdateText;
    }

    public override void DisableListener()
    {
        weapon.OnCooldownChange -= UpdateText;
    }

    public override void UpdateText(float value)
    {
        text.text = value.ToString();
    }
}
