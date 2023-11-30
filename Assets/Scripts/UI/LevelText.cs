public class LevelText : UIElement
{
    private void OnDisable() 
    {
        DisableListener();
    }

    public override void SetupListener(Player player)
    {
        base.SetupListener(player);
        player.OnLevelChange += UpdateText;
    }

    public override void DisableListener()
    {
        player.OnLevelChange -= UpdateText;
    }

    public override void UpdateText(int value)
    {
        text.text = "Level: " + value;
    }
}
