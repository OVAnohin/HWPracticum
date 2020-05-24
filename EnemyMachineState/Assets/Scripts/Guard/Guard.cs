using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
  [SerializeField] private Player _target = null;
  [SerializeField] private float _speed = 3f;
  [SerializeField] private int _health = 5;

  public float Speed
  {
    get { return _speed; }
  }

  public Player Target 
  {
    get { return _target; }
  }

  public void TakeDamage(int damage)
  {
    _health -= damage;

    if (_health <= 0)
    {
      Destroy(gameObject);
    }
  }
}
