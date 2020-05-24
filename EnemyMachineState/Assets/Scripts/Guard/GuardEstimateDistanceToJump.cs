using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardEstimateDistanceToJump : State
{
  [SerializeField] private Transform _gapCheck = null;
  [SerializeField] private LayerMask _whatIsGround = 0;
  [SerializeField] private float _distanceCheck = 2f;

  public bool IsJumpRight { get; private set; }
  private void OnEnable()
  {
    EstimateDistance();
  }

  private void EstimateDistance()
  {
    if (transform.eulerAngles.y == 180f)
      IsJumpRight = Physics2D.Raycast(_gapCheck.position, Vector2.left, _distanceCheck, _whatIsGround);
    else
      IsJumpRight = Physics2D.Raycast(_gapCheck.position, Vector2.right, _distanceCheck, _whatIsGround);
  }
}
