﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;

public class GameHandler : MonoBehaviour {

    private static GameHandler instance;

   [SerializeField] private Snake snake;

     private LevelGrid levelGrid;

    private void Awake()
    {
        instance = this;
        Score.InitializeStatic();
        Time.timeScale = 1f;

        Score.TrySetNewHighscore(200);
    }
    
    private void Start() {
        Debug.Log("GameHandler.Start\n");

        levelGrid = new LevelGrid(20, 20);

        snake.Setup(levelGrid);
        levelGrid.Setup(snake);
        GameHandler.ResumeGame();
    }

    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGamePaused()) {
                GameHandler.ResumeGame();
            } else
            {
                GameHandler.PauseGame();
            }
            
        } 
    }

    public static void SnakeDied()
    {
        Score.TrySetNewHighscore();
        GameOverWindow.ShowStatic();
    }
    public static void ResumeGame()
    {
        PauseWindow.HideStatic();
        Time.timeScale = 1f;
    }

    public static void PauseGame()
    {
        PauseWindow.ShowStatic();
        Time.timeScale = 0f;
    }

    public static bool IsGamePaused()
    {
        return Time.timeScale == 0f;
    }
}
