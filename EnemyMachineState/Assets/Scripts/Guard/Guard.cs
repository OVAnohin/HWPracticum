using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
  [SerializeField] private Player _target = null;
  [SerializeField] private float _speed = 3f;

  public float Speed
  {
    get { return _speed; }
  }

  public Player Target 
  {
    get { return _target; }
  }
}
