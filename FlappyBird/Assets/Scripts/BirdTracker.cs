using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// скрипт для управления камерой для птицы
// крепится на камеру

public class BirdTracker : MonoBehaviour
{
  [SerializeField] private Bird _bird;
  [SerializeField] private float _xOffset = -2.5f; // смещаем камеру по x для того что бы немного видеть заранее.

  private void Start()
  {

  }

  private void Update()
  {
    transform.position = new Vector3(_bird.transform.position.x - _xOffset, transform.position.y, transform.position.z);
  }
}
