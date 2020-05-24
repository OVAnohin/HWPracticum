using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GuardEstimateDistanceToJump))]
public class EstimateDistanceToJumpTransition : Transition
{
  private State _targetState = null;

  public override State TargetState
  {
    get { return _targetState; }
  }

  private void OnEnable()
  {
    NeedTransit = false;
  }

  private void Update()
  {
    if (GetComponent<GuardEstimateDistanceToJump>().IsJumpRight)
    {
      _targetState = (from value in TargetStates
                      where value is GuardJump
                      select value).First();
    }
    else
    {
      _targetState = (from value in TargetStates
                      where value is GuardSearchTarget
                      select value).First();
    }

    NeedTransit = true;
  }
}
