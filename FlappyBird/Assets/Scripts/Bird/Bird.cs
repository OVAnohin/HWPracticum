using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
  private BirdMover _birdMover;
  private int _score;

  public event UnityAction GameOver;
  public event UnityAction<int> ScoreChanged;

  private void Start()
  {
    _birdMover = GetComponent<BirdMover>();
  }

  public void ResetPlayer()
  {
    _score = 0;
    ScoreChanged?.Invoke(_score);
    _birdMover.ResetBird();
  }

  public void Die()
  {
    GameOver?.Invoke();
  }

  public void IncreaseScore()
  {
    _score += 1;
    ScoreChanged?.Invoke(_score);
  }
}
