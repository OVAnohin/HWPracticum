using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Guard))]

public class GuardSearchTarget : State
{
  [SerializeField] private float _timeSearch = 1f;
  [SerializeField] private float _distanceCheck = 5f;

  public bool IsTargetFound { get; private set; }
  public bool IsEndSearch { get; private set; }

  private float _elapsedTime = 0;
  private bool _lookToRight;
  private bool _isSwhithed;
  private int _layerMask;

  private void OnEnable()
  {
    IsTargetFound = false;
    IsEndSearch = false;
    _isSwhithed = false;
    _layerMask = LayerMask.GetMask(LayerMask.LayerToName(Target.gameObject.layer));
    _elapsedTime = _timeSearch;

    if (transform.eulerAngles.y == 180f)
      _lookToRight = false;
    else
      _lookToRight = true;

    StartCoroutine(SearchTarget());
  }

  private IEnumerator SearchTarget()
  {
    while (_elapsedTime > 0)
    {
      if (_lookToRight)
        IsTargetFound = Physics2D.Raycast(transform.position, Vector2.right, _distanceCheck, _layerMask);
      else
        IsTargetFound = Physics2D.Raycast(transform.position, Vector2.left, _distanceCheck, _layerMask);

      if (IsTargetFound)
        break;

      if (_elapsedTime < _timeSearch / 2 && _isSwhithed == false)
        SwitchDirection();

      _elapsedTime -= Time.deltaTime;

      yield return null;
    }

    IsEndSearch = true;
  }

  private void SwitchDirection()
  {
    if (_lookToRight)
    {
      transform.eulerAngles = new Vector3(0, -180, 0);
      _lookToRight = false;
    }
    else
    {
      transform.eulerAngles = new Vector3(0, 0, 0);
      _lookToRight = true;
    }

    _isSwhithed = true;
  }
}
