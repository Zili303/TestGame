using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelSystem : MonoBehaviour
{
    private Player player;

    [SerializeField] private List<PlayerStats> playerLevels;
    public event Action<PlayerStats> OnPlayerLevelUp;

    private void Awake() 
    {
        player = GetComponent<Player>();
    }

    private void Update() 
    {
        CheckPlayerLevelUp();
    }

    public void ResetLevel()
    {
        OnPlayerLevelUp?.Invoke(playerLevels[0]);
        Debug.Log("LEVEL UP");
    }

    private void CheckPlayerLevelUp()
    {
        if (player.CheckLevelUp())
        {
            int nextLevel = player.Level + 1;

            if (nextLevel < playerLevels.Count)
            {
                OnPlayerLevelUp?.Invoke(playerLevels[nextLevel]);
            }
        }
    }
}
