using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
  [SerializeField] private int _health; //жизнь 
  [SerializeField] private int _reward; //бонус за победу над врагом

  private Player _target; //цель для нашего врага

  public event UnityAction Dying;   // событие которое говорит что этот объект умер.
  public int Reward => _reward;
  public Player Target => _target;  //свойство выдачи нашего врага, объект цель наша

  public void Init(Player player) //наш инит, что то типа замена конструктора
  {
    _target = player;
  }

  public void TakeDamage(int damage) // тут принимаем урон
  {
    _health -= damage;

    if (_health <= 0)
    {
      Destroy(gameObject);
      Dying.Invoke();
    }
  }
}
