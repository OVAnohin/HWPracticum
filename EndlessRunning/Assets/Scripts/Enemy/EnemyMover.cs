using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
  [SerializeField] private float _moveSpeed = 5;

  private void Update()
  {
    transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
  }
}
