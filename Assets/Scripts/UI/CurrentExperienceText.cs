public class CurrentExperienceText : UIElement
{
    private void OnDisable() 
    {
        DisableListener();
    }

    public override void SetupListener(Player player)
    {
        base.SetupListener(player);
        player.OnCurrentExperienceChange += UpdateText;
    }

    public override void DisableListener()
    {
        player.OnCurrentExperienceChange -= UpdateText;
    }

    public override void UpdateText(float value)
    {
        text.text = value.ToString();
    }
}
