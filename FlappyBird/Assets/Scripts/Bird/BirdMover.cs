using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] // управлять будем с помощью физики

public class BirdMover : MonoBehaviour
{
  [SerializeField] private Vector3 _startPosition; // наша стартовая позиция
  [SerializeField] private float _speed = 0; // птица летит в право...нужна скорость
  [SerializeField] private float _tapForce = 250; // птица у нас подлетает при нажатии (подпрыгивает) 
  [SerializeField] private float _rotationSpeed = 1; // это у нас скорость вращения
  [SerializeField] private float _maxRotationZ = 35; // диапазон вращения, 360 мы не можем крутиться
  [SerializeField] private float _minRotationZ = -60; // 

  private Rigidbody2D _rigidbody2D;
  private Quaternion _maxRotation; // Quaternion отвечает за повороты
  private Quaternion _minRotation;

  private void Start()
  {
    _rigidbody2D = GetComponent<Rigidbody2D>();

    _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ); // максимальный угол, на который птица задирает голову
    _minRotation = Quaternion.Euler(0, 0, _minRotationZ); // максимальный угол, на который птица опускает голову

    ResetBird();
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space)) // на пробел вешаем скачек вверх
    {
      _rigidbody2D.velocity = new Vector2(_speed, 0); // мы гасим скорость, что бы она не накапливалась
      transform.rotation = _maxRotation; // при нажатии на пробел мы задираем голову вверх по максимуму
      _rigidbody2D.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
    }

    // тут мы выравниваем пницу, опускаем голову назад плавно.
    transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
  }

  // метод сброса всего в начальное положение
  public void ResetBird()
  {
    transform.position = _startPosition; // обнуляем нашу стартовую позицию (ставим на начало)
    transform.rotation = Quaternion.Euler(0, 0, 0);
    _rigidbody2D.velocity = Vector2.zero;
  }
}
