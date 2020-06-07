using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
  [SerializeField] private List<Weapon> _weapons; // список нашего оружия 
  [SerializeField] private Player _player; // наш пользователь, для взаимодействия
  [SerializeField] private WeaponView  _template; // наш шаблон отображение оружия, prefab из оружия -> (weapon из scrollView)
  [SerializeField] private GameObject  _itemContainer; // место, куда мы генирируем оружие, тут будут наши товары (content из scrollView)

  private void Start()
  {
    for (int i = 0; i < _weapons.Count; i++)
    {
      AddItem(_weapons[i]); //погнали создавать и рисовать наше оружие
    }
  }

  //метод создания оружия, т.к он включает в себя не только создание
  private void AddItem(Weapon weapon)
  {
    var view = Instantiate(_template, _itemContainer.transform); // создаем наше оружие
    view.SellButtonClick += OnSellButtonClick; // подписка на кнопку продажи
    view.Render(weapon); // отрисовываем наше оружие
  }

  // метод, обработки нажатия кнопки покупки
  private void OnSellButtonClick(Weapon weapon, WeaponView view)
  {
    // для понимания, это кнопка, а что мы хотим сделать, после нажания на эту кнопку
    // мы хотим попытаться продать оружие
    TrySellWeapon(weapon, view);
  }

  // но для ясности мы передадим нажатие на кнопку другому методу
  // мы попытаемся продать оружие
  private void TrySellWeapon(Weapon weapon, WeaponView view)
  {
    if (weapon.Price <= _player.Money)
    {
      _player.BuyWeapon(weapon);
      weapon.Buy(); // для того что бы мы явно видели, что оружие куплено
      // и тут надо отписаться от события нажатия на кнопку
      view.SellButtonClick -= OnSellButtonClick; // отписка на кнопку продажи
    }
  }
}
