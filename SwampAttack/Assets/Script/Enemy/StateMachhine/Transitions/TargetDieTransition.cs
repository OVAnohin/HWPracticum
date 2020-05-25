using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//переход если цель пропала, мы убили player
public class TargetDieTransition : Transition
{
  private void Update()
  {
    if (Target == null)
    {
      NeedTransit = true;
    }
  }
}
