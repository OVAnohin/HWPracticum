using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class EnemyStateMachine : MonoBehaviour
{
  [SerializeField] private State _firstState; //первое состояние, начало.

  private Player _target; // цель состояния, куда идти или кого бить.
  private State _currentState; // состояние в котором находимся сейчас.

  public State Current //свойство получения текущего состояния.
  {
    get { return _currentState; }
  }

  private void Start()
  {
    _target = GetComponent<Enemy>().Target; //получаем нашего врага, цель (это наш player)
    Reset(_firstState); // переходим в начальное состояние, первая установка
  }

  private void Reset(State startState) //сброс в состояние. тут в самое начало. Может кто то сможет воспользоваться.
  {
    _currentState = startState;

    if (_currentState != null) 
      _currentState.Enter(_target);
  }

  private void Update()
  {
    if (_currentState == null) //если нет состояния выходим
      return;

    // если есть состояние, то для начала мы берем состояние, куда бы мы могли пойти.
    // по просту проверяем, был ли переход
    var nextState = _currentState.GetNextState();
    if (nextState != null) //есть новое состояние - надо в него перейти.
      Transit(nextState);
  }

  //метод перехода в новое состояние
  private void Transit(State nextState)
  {
    if (_currentState != null) //если мы в каком то состоянии, то из него надо выйти
      _currentState.Exit();

    _currentState = nextState;

    if (_currentState != null)
      _currentState.Enter(_target);
  }
}
