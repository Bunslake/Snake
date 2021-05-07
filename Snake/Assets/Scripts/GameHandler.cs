﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;

public class GameHandler : MonoBehaviour {

    private static GameHandler instance;

    private static int score;

    [SerializeField] private Snake snake;

     private LevelGrid levelGrid;

    private void Awake()
    {
        instance = this;
    }
    
    private void Start() {
        Debug.Log("GameHandler.Start");

        levelGrid = new LevelGrid(20, 20);

        snake.Setup(levelGrid);
        levelGrid.Setup(snake);

        CMDebug.ButtonUI(Vector2.zero, "Reload scene", () =>
        {
            Loader.Load(Loader.Scene.GameScene);
        });

    }

    public static int GetScore()
    {
        return score;
    }
    
    public static void AddScore()
    {
        score += 100; 
    }

}
