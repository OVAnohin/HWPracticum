using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
  [SerializeField] private TMP_Text _scoreText;
  [SerializeField] private Player _player;

  private void OnEnable()
  {
    _player.ScoreChanged += OnScoreChanged;
  }

  private void OnDisable()
  {
    _player.ScoreChanged -= OnScoreChanged;
  }

  private void OnScoreChanged(int score)
  {
    _scoreText.text = score.ToString();
  }
}
