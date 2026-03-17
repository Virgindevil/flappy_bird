using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private PipeGenerator _pipeSpawner;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnEnable()
    {
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _bird.GameOver += OnGemeOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _bird.GameOver -= OnGemeOver;
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Closed();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _gameOverScreen.Closed();
        _pipeSpawner.ResetPool();
        StartGame();
    }

    private void StartGame()
    {
        _bird.ReserPlayer();
        Time.timeScale = 1;
    }

    public void OnGemeOver()
    {
        Time.timeScale = 0;
        _gameOverScreen.Open();
    }

}
