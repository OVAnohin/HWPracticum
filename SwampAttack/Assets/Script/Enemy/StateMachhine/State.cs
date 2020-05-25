using System.Collections.Generic;
using UnityEngine;

// состояния для машины
// тут должны быть четкие условия перехода - "transition", проверки выхода из состояния
public abstract class State : MonoBehaviour
{
  [SerializeField] private List<Transition> _transitions; //список проверок условий выходов

  protected Player Target { get; set; } //наша цель что и куда

  // вход в наше состояние
  // мы тут принимаем нашу цель, что бы наше состояние знало о том, кто наша цель.
  // тут тонкость реализации, Start и Update работают только когда скрипт включен 
  // но все методы при этом рабочие
  // все наши состояния будут висеть на одном объекте и в Update будет написано, на пример бить или двигаться
  // и нам нужно будет выключать скрипт. (состояние)
  public void Enter(Player target)
  {
    if (enabled == false) //наш скрипт выключен?
    {
      Target = target;
      enabled = true; //включаем наш скрипт
      foreach (var transition in _transitions) // тут мы хотим перебрать все наши переходы(проверки) и каждое состояние включить.
      {
        transition.enabled = true; // включаем наши транзишионы (это что то типа проверяльшиков, достигли ли мы чего то....)
        transition.Init(Target);   // мы инициируем наши транзишионы                       
      }                            // мы передаем туда нашу цель
    }                              // для того что бы мы знали до чего дойти или бить или ещё что
  }

  //метод выхода из состояния
  //если скрипт включен, выключить, и все переходы выключить.
  public void Exit()
  {
    if (enabled == true)
    {
      foreach (var transition in _transitions)
        transition.enabled = false;

      enabled = false;
    }
  }

  // тут получаем(проверяем) возник ли переход, сработал ли один из transition
  public State GetNextState()
  {
    foreach (var transition in _transitions)
    {
      if (transition.NeedTransit)       //если нужен переход
        return transition.TargetState;  //то тогда пора переходить переходить в состояние
    }

    return null; //ничего не нашли, куда идти, нет перехода
  }
}
