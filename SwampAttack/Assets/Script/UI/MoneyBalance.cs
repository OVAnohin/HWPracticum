﻿using TMPro;
using UnityEngine;

public class MoneyBalance : MonoBehaviour
{
  [SerializeField] private TMP_Text _money;
  [SerializeField] private Player _player;

  // нужен метод отображения денег от игрока
  // в момент включения скрипта (отображения магазина) просто выводим деньги игрока
  private void OnEnable()
  {
    _money.text = _player.Money.ToString();
  }
}
