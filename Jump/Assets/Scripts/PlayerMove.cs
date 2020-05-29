using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
  [SerializeField] private float _speed;

  //y=-x2+4x
  private float _elapsedTime = 0;

  private void Update()
  {
    if (!(_elapsedTime > 1))
    {
      transform.Translate(transform.right * _speed * Time.deltaTime);
    }
    _elapsedTime += Time.deltaTime;
  }
}
