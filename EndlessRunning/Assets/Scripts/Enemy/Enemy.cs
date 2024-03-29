﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField] private int _damage;

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.GetComponent<Player>() != null)
    {
      collision.GetComponent<Player>().ApplyDamage(_damage);
    }

    Die();
  }



  private void Die()
  {
    gameObject.SetActive(false);
  }
}
