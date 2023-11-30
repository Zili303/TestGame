public class HealthText : UIElement
{
    private void OnDisable() 
    {
        DisableListener();
    }

    public override void SetupListener(Player player)
    {
        base.SetupListener(player);
        player.OnCurrentHealthChange += UpdateText;
    }

    public override void DisableListener()
    {
        player.OnCurrentHealthChange -= UpdateText;
    }

    public override void UpdateText(float value)
    {
        text.text = "Health: " + value;
    }
}
