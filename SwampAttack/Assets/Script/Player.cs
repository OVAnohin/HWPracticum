using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
  [SerializeField] private int _health; //жизня
  [SerializeField] private List<Weapon> _weapons; //коллекция нашего оружия
  [SerializeField] private Transform _shootPoing; //точка откуда летят пули

  public int Money { get; private set; } // наши деньги
  public UnityAction<int, int> HealthChanged; //событие изменения жизни

  private Weapon _currentWeapon; //текущее оружие
  private int _currentHealth;    //тукущая жизня
  private Animator _animator;
  

  private void Start()
  {
    _currentWeapon = _weapons[0];
    _currentHealth = _health;
    _animator = GetComponent<Animator>();
    HealthChanged(_currentHealth, _health);
  }

  public void ApplyDamage(int damage)
  {
    _currentHealth -= damage;
    HealthChanged(_currentHealth, _health);

    if (_currentHealth <= 0)
      Destroy(gameObject);
  }

  public void AddMoney(int reward) //событие получение денег от врага
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
