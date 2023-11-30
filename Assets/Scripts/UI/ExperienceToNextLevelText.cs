public class ExperienceToNextLevelText : UIElement
{
    private void OnDisable() 
    {
        DisableListener();
    }

    public override void SetupListener(Player player)
    {
        base.SetupListener(player);
        player.OnExperienceLevelChange += UpdateText;
    }

    public override void DisableListener()
    {
        player.OnExperienceLevelChange -= UpdateText;
    }

    public override void UpdateText(float value)
    {
        text.text = value.ToString();
    }
}
