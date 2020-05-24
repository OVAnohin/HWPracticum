using System.Linq;
using UnityEngine;

[RequireComponent(typeof(GuardAttack))]

public class AttackTransition : Transition
{
  private State _targetState = null;

  private float _elapsedTime = 0;

  public override State TargetState
  {
    get { return _targetState; }
  }

  private void OnEnable()
  {
    NeedTransit = false;
    _elapsedTime = 0;
  }

  private void Update()
  {
    if (_elapsedTime > GetComponent<GuardAttack>().Dalay)
    {
      NeedTransit = true;
      _targetState = (from value in TargetStates
                      where value is GuardSearchTarget
                      select value).First();
    }

    _elapsedTime += Time.deltaTime;
  }
}
