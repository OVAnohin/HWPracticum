using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : MonoBehaviour
{
  [SerializeField] private ParticleSystem _particle;

  private void Start()
  {
    _particle.Stop();
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.TryGetComponent<Head>(out Head head))
    {
      _particle.Play();
    }
  }
}
