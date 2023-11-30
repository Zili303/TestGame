using System;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private GameStateController gameStateController;
    public PlayerStats Stats;
    private PlayerLevelSystem playerLevelSystem;
    private PlayerInput playerInput;
    private PlayerMovement playerMovement;
    
    private float CurrentExperience;
    private float ExperienceToNextLevel;
    private int Score;

    public int Level { get; private set; }

    public event Action<int> OnScoreChange;
    public event Action<int> OnLevelChange;
    public event Action<float> OnCurrentExperienceChange;
    public event Action<float> OnExperienceLevelChange;

    private void OnEnable() 
    {
        playerLevelSystem.OnPlayerLevelUp += LevelUp;
        gameStateController.OnGameEnd += OnGameEnd;
        gameStateController.OnGameStart += OnGameStart;
    }

    private void OnDisable() 
    {
        playerLevelSystem.OnPlayerLevelUp -= LevelUp;
        gameStateController.OnGameEnd -= OnGameEnd;
        gameStateController.OnGameStart -= OnGameStart;
    }

    private void Awake() 
    {
        playerLevelSystem = GetComponent<PlayerLevelSystem>();
        playerInput = GetComponent<PlayerInput>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update() 
    {
        CheckForEndGame();
    }

    private bool isDead()
    {
        return CurrentHealth <= 0;
    }

    private void CheckForEndGame()
    {
        if (isDead())
        {
            EndGame();
        }
    }
    
    private void EndGame()
    {
        gameStateController.EndGame();
    }

    private void OnGameStart()
    {
        playerInput.EnableInput();
        playerLevelSystem.ResetLevel();
        playerMovement.ResetPosition();
        ResetScore();
        ResetCurrentExperience();
        ResetCurrentHealth();
    }

    private void OnGameEnd()
    {
        playerInput.DisableInput();
    }

    private void ModifyCurrentExperience(float value)
    {
        CurrentExperience = value;
        OnCurrentExperienceChange?.Invoke(CurrentExperience);
    }

    private void ModifyExperienceToNextLevel(float value)
    {
        ExperienceToNextLevel = value;
        OnExperienceLevelChange?.Invoke(ExperienceToNextLevel);
    }

    private void ModifyLevel(int value)
    {
        Level = value;
        OnLevelChange?.Invoke(Level);
    }

    private void ModifyScore(int value)
    {
        Score = value;
        OnScoreChange?.Invoke(Score);
    }

    public void ResetCurrentExperience()
    {
        ModifyCurrentExperience(0);
    }

    public void ResetCurrentHealth()
    {
        ModifyHealth(MaxHealth);
    }

    public void ResetScore()
    {
        ModifyScore(0);
    }

    public bool CheckLevelUp()
    {
        return CurrentExperience >= ExperienceToNextLevel;
    }

    public void LevelUp(PlayerStats nextLevel)
    {
        ModifyLevel(nextLevel.Level);
        ModifyExperienceToNextLevel(nextLevel.ExperienceToNextLevel);
        ModifyMaxHealth(nextLevel.MaxHealth);
        
        ResetCurrentHealth();        
    }

    public void GainScore(int value)
    {
        ModifyScore(Score + value);
    }
    
    public void GainExperience(int value)
    {
        ModifyCurrentExperience(CurrentExperience + value);
    }
}
