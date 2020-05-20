using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
  [SerializeField] private int _health;
  [SerializeField] private List<Weapon> _weapons;
  [SerializeField] private Transform _shootPoing;

  public int Money { get; private set; }

  private Weapon _currentWeapon;
  private int _currentHealth;
  private Animator _animator;

  private void Start()
  {
    _currentWeapon = _weapons[0];
    _currentHealth = _health;
    _animator = GetComponent<Animator>();
  }

  private void EnemyDying(int reward)
  {
    Money += reward;
  }

  private void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      _currentWeapon.Shoot(_shootPoing);
    }
  }
}
