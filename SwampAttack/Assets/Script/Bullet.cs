using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  [SerializeField] private int _damage = 1;
  [SerializeField] private float _speed = 10;

  private void Update()
  {
    transform.Translate(Vector2.left * _speed * Time.deltaTime, Space.World);
  }

  private void OnTriggerEnter2D(Collider2D collider2D)
  {
    if (collider2D.GetComponent<Enemy>() != null)
    {
      collider2D.GetComponent<Enemy>().TakeDamage(_damage);
      Destroy(gameObject);
    }
  }
}
