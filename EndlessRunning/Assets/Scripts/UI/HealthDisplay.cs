using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
  [SerializeField] private Player _player;
  [SerializeField] private TMP_Text _healthDisplay;

  private void OnEnable()
  {
    _player.HealthChanged += ChangeHealtOnDisplay;
  }

  private void OnDisable()
  {
    _player.HealthChanged -= ChangeHealtOnDisplay;
  }

  private void ChangeHealtOnDisplay(int health)
  {
    _healthDisplay.text = health.ToString();
  }
}
