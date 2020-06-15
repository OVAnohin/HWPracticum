using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
  private int _score;

  public event UnityAction<int> ScoreChanged;

  public void AddScore()
  {
    _score++;
    ScoreChanged?.Invoke(_score);
  }
}
