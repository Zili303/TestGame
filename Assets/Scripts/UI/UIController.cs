using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameStateController gameStateController;
    [SerializeField] private Player player;
    [SerializeField] private GameObject gameOverPanel;
    private UIElement[] uiElements;

    private void OnEnable() 
    {
        gameStateController.OnGameStart += OnGameStart;
        gameStateController.OnGameEnd += OnGameEnd;
    }

    private void OnDisable() 
    {
        gameStateController.OnGameStart -= OnGameStart;
        gameStateController.OnGameEnd -= OnGameEnd;
    }

    private void Start() 
    {
        FindUIElements();
        SetupListners();
    }

    private void OnGameStart()
    {
        gameOverPanel.SetActive(false);
    }

    private void OnGameEnd()
    {
        gameOverPanel.SetActive(true);
    }

    private void FindUIElements()
    {
        uiElements = GetComponentsInChildren<UIElement>();
    }

    private void SetupListners()
    {
        foreach (UIElement uiElement in uiElements)
        {
            uiElement.SetupListener(player);
        }
    }
}
