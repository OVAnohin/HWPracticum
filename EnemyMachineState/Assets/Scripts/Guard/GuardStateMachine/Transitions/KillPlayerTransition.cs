using System.Linq;
using UnityEngine;

public class KillPlayerTransition : Transition
{
  private State _targetState = null;

  public override State TargetState
  {
    get { return _targetState; }
  }
  private void Update()
  {
    if (Target == null)
    {
      NeedTransit = true;
      _targetState = (from value in TargetStates
                      where value is GuardStop
                      select value).First();
    }
  }
}
