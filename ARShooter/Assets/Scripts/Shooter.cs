using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
  // нам нужно иметь пулю, которую будем стрелять
  // и точку из которой пуля полетит
  [SerializeField] private Transform _shootPoint;
  [SerializeField] private Bullet _bulletTemplate; // тут будет префаб пули

  // Update is called once per frame
  private void Update()
  {
    //if (Input.GetMouseButtonDown(0)) // пока нажатие будет мышь
    if (Input.touchCount > 0) // 
    {
      if (Input.GetTouch(0).phase == TouchPhase.Began) // если мы только коснулись
      {
        Instantiate(_bulletTemplate, _shootPoint);
      }
    }
  }
}
