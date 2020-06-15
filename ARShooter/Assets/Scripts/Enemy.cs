using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
  [SerializeField] private ParticleSystem _deathEffect; //эффект смерти

  public event UnityAction<Enemy> EnemyDied;

  public void Die() 
  {
    //создаем эффект смерти, на месте объекта и без поворотов
    //Instantiate(_deathEffect, transform.position, Quaternion.identity);
    EnemyDied?.Invoke(this);
    Destroy(gameObject);
  }
}
