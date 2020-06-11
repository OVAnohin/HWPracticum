using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// наш основной файл обработки игры
// будет перезапускать
// нам нужно ещё начальный экран, экран конечный, перезапуска....
// для этого будут скрипты
// добавляем canvas, canvas будет по камере
// на GameOverScreen убрать Raycast target на Image
// Game навешан на mainCamera

public class Game : MonoBehaviour
{
  [SerializeField] private Bird _bird;
  [SerializeField] private WallGenerator _wallGenerator;
  [SerializeField] private StartScreen _startScreen;
  [SerializeField] private GameOverScreen _gameOverScreen;



  private void OnEnable()
  {
    _startScreen.PlayButtonClick += OnPlayButtonClick;
    _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
    _bird.GameOver += OnGameOver;
  }


  private void OnDisable()
  {
    _startScreen.PlayButtonClick -= OnPlayButtonClick;
    _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
    _bird.GameOver -= OnGameOver;
  }

  private void Start()
  {
    Time.timeScale = 0;
    _startScreen.Open();
  }

  private void OnPlayButtonClick()
  {
    _startScreen.Close();
    StartGame();
  }

  private void OnRestartButtonClick()
  {
    _gameOverScreen.Close();
    _wallGenerator.ResetPool();
    StartGame();
  }

  private void StartGame()
  {
    Time.timeScale = 1;
    _bird.ResetPlayer();
  }

  public void OnGameOver()
  {
    Time.timeScale = 0;
    _gameOverScreen.Open();
  }
}
