public class ScoreText : UIElement
{
    private void OnDisable() 
    {
        DisableListener();
    }

    public override void SetupListener(Player player)
    {
        base.SetupListener(player);
        player.OnScoreChange += UpdateText;
    }

    public override void DisableListener()
    {
        player.OnScoreChange -= UpdateText;
    }

    public override void UpdateText(int value)
    {
        text.text = "Score: " + value;
    }
}
