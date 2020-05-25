using UnityEngine;

[RequireComponent(typeof(Animator))]

public class AttackState : State
{
  [SerializeField] private int _damage = 1;
  [SerializeField] private float _delay = 1f;

  private float _lastAttackTime;
  private Animator _animator;

  private void Start()
  {
    _animator = GetComponent<Animator>();
  }

  private void Update()
  {
    if (_lastAttackTime <= 0)
    {
      Attack(Target);
      _lastAttackTime = _delay;
    }

    _lastAttackTime -= Time.deltaTime;
  }

  private void Attack(Player target)
  {
    _animator.Play("Attack");
    target.ApplyDamage(_damage);
  }
}
