using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
  [SerializeField] private int _health; //жизня
  [SerializeField] private List<Weapon> _weapons; //коллекция нашего оружия
  [SerializeField] private Transform _shootPoing; //точка откуда летят пули

  public int Money { get; private set; } // наши деньги

  private Weapon _currentWeapon; //текущее оружие
  private int _currentHealth;    //тукущая жизня
  private Animator _animator;

  private void Start()
  {
    _currentWeapon = _weapons[0];
    _currentHealth = _health;
    _animator = GetComponent<Animator>();
  }

  public void ApplyDamage(int damage)
  {
    _currentHealth -= damage;

    if (_currentHealth <= 0)
      Destroy(gameObject);
  }

  private void OnEnemyDyed(int reward) //событие получение денег от врага
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
