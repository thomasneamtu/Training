using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GameController : MonoBehaviour
{
    private Puzzle currentpuzzle;
    [SerializeField] private Puzzle[] allPuzzles;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private GameObject player;
    [SerializeField] private AudioSource endMusic;
    [SerializeField] private GameObject gameplayMusic;
    public bool IsGameOver = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        IsGameOver = true;
        uiManager.DisplayEndScreen();
        endMusic.Play();
        gameplayMusic.SetActive(false);
    }
}
