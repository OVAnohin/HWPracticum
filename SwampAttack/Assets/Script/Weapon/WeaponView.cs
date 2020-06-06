using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// это некое отображение оружия, специально, что бы в магазин кроме оружия ничего больше не затискать
public class WeaponView : MonoBehaviour
{
  // все описания, цены это TMP_text
  [SerializeField] private TMP_Text _label; 
  [SerializeField] private TMP_Text _price; 
  [SerializeField] private Image _icon; 
  [SerializeField] private Button _sellButton;

  // наш shop "слушает" товар, что его хотят купить
  // он берет и проверяет может ли тебе продать товар, если да продаем
  // тут мы так же передаем себя, для того что бы можно было отписаться от события
  public event UnityAction<Weapon, WeaponView> SellButtonClick;

  private Weapon _weapon; // мы храним наше оружие, которое хотим продать

  private void OnEnable()
  {
    _sellButton.onClick.AddListener(OnButtonClick); // подписываемся на событие нажатия на кнопку
    _sellButton.onClick.AddListener(TryLockItem);  // событие выключения кнопки продажа
  }

  private void OnDisable()
  {
    _sellButton.onClick.RemoveListener(OnButtonClick);
    _sellButton.onClick.RemoveListener(TryLockItem);
  }

  //тут мы ещё отрисовывам наш объект
  public void Render(Weapon weapon)
  {
    //установка оружия и занесение данных по своим местам
    _weapon = weapon;
    _label.text = _weapon.Label;
    _price.text = _weapon.Price.ToString();
    _icon.sprite = _weapon.Icon;
  }

  // метод обработки нажатия на нашу кнопку
  private void OnButtonClick()
  {
    SellButtonClick?.Invoke(_weapon, this);
  }

  // если этот товар уже был продан, то мы не должны его ещё раз продать
  // пробуем его заблокировать
  private void TryLockItem()
  {
    if (_weapon.IsBye)
      _sellButton.interactable = false; // выключаем нашу кнопку продажи
  }
}
