using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// обработчик столкновения птицы

[RequireComponent(typeof(Bird))]
public class BirdCollisionHandler : MonoBehaviour
{
  private Bird _bird;

  void Start()
  {
    _bird = GetComponent<Bird>();
  } 

  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.GetComponent<ScoreZone>() != null)
    {
      _bird.IncreaseScore();
      return;
    }

    _bird.Die();
  }
}
