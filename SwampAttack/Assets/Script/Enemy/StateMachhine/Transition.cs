using UnityEngine;

//это шаблон для transition
//это проверяльщик, дошли ли и.т.д. наши проверки условий окончания состояния

public abstract class Transition : MonoBehaviour
{
  [SerializeField] private State _targetState; // это поле для состояния, в которое мы перейдем, если переход состоится

  public bool NeedTransit { get; protected set; } //нам пора переходить, его будут менять наши "дети", когда условие выполнится
  protected Player Target { get; private set; }   //наша цель.

  public State TargetState // получение нашего следующего состояния
  {
    get { return _targetState; }
  }


  public void Init(Player target) //инициализация нашим player, кто цель
  {
    Target = target;
  }

  private void OnEnabled()
  {
    NeedTransit = false; //по умолчинию мы некуда не хотим переходить.
  }
}
