﻿using System.Linq;
using UnityEngine;

[RequireComponent(typeof(GuardSearchTarget))]

public class SearchTargetTransition : Transition
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
    if (GetComponent<GuardSearchTarget>().IsEndSearch)
    {
      NeedTransit = true;
      _targetState = (from value in TargetStates
                      where value is GuardMover
                      select value).First();
    }

  }
}
