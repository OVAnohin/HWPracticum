using UnityEngine;

// это переход от ходьбы к удару
// тут мы проверяем, мы дошли до цели, да дошли нужен переход

public class DistanceTransition : Transition
{
  [SerializeField] private float _transitionRange; 
  [SerializeField] private float _rangeSpread;

  private void Start()
  {
    _transitionRange += Random.Range(-_rangeSpread, _rangeSpread);
  }

  private void Update()
  {
    if (Vector2.Distance(transform.position, Target.transform.position) < _transitionRange)
    {
      NeedTransit = true;
    }
  }
}
