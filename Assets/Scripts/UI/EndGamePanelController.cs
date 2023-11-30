using UnityEngine;
using TMPro;

public class EndGamePanelController : MonoBehaviour
{
    [SerializeField] private TMP_Text gameOverScoreText;
    [SerializeField] private TMP_Text scoreText;

    private void OnEnable() 
    {
        gameOverScoreText.text = scoreText.text;
    }
}
