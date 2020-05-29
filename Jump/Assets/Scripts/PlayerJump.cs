using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
  [SerializeField] private float _speed;

  //y=-x2+4x
  private float _elapsedTime = 0;
  private float _endTimeJump;
  private int _lengthJump = 3;
  private Vector3 vector3 = new Vector3(0, 0, 0);
  private Vector3 _startPosition;

  private void Start()
  {
    _startPosition = transform.position;
    _endTimeJump = _lengthJump / _speed;
    Debug.Log(_endTimeJump);
  }

  private void Update()
  {
    if (!(_elapsedTime > _endTimeJump))
    {
      //transform.Translate(Vector2.right * _speed * Time.deltaTime);
      vector3.x = Mathf.Lerp(0f, _lengthJump, _elapsedTime);
      //vector3.x = _elapsedTime;
      // Debug.Log("vector3.x - " + vector3.x);
      //Debug.Log("_elapsedTime" + _elapsedTime);
      vector3.y = (-(vector3.x * vector3.x)) + (int)_lengthJump * vector3.x;
      //Debug.Log(vector3.y);
      transform.position = _startPosition + vector3;
      //transform.Translate(vector3 * _speed * Time.deltaTime);
    }
    _elapsedTime += Time.deltaTime;
  }
}
