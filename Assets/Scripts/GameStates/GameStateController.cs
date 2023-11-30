using System;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    public event Action OnGameStart;
    public event Action OnGameEnd;

    private void Start() 
    {
        StartGame();
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        OnGameStart?.Invoke();
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        OnGameEnd?.Invoke();
    }
}
