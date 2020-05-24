using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GuardJump))]

public class JumpTransition : Transition
{
  public override State TargetState
  {
    get { return TargetStates[0]; }
  }

  private void OnEnable()
  {
    NeedTransit = false;
  }

  private void Update()
  {
    if (GetComponent<GuardJump>().IsEndJump)
    {
      NeedTransit = true;
    }
  }
}
