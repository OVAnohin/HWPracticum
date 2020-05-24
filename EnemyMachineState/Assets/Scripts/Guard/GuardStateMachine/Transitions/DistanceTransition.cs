using System.Linq;
using UnityEngine;

public class DistanceTransition : Transition
{
  [SerializeField] private float _transitionRange = 0;
  [SerializeField] private float _rangeSpread = 0;

  private State _targetState = null;

  private void Start()
  {
    _transitionRange += Random.Range(-_rangeSpread, _rangeSpread);
  }

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
    if (Vector2.Distance(transform.position, Target.transform.position) < _transitionRange)
    {
      Debug.Log(Vector2.Distance(transform.position, Target.transform.position) < _transitionRange);
      NeedTransit = true;
      _targetState = null;
      //_targetState = (from value in TargetStates
      //                where value is GuardJump
      //                select value).First();
    }
  }
}
