using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class GuardJump : State
{
  [SerializeField] private Transform _groundCheck = null;
  [SerializeField] private LayerMask _whatIsGround = 0;
  [SerializeField] private float _jumpForce = 5f;

  public bool IsEndJump { get; private set; }

  private Rigidbody2D _rigidbody2D;

  private void OnEnable()
  {
    IsEndJump = false;
    _rigidbody2D = GetComponent<Rigidbody2D>();
    StartCoroutine(Jump());
  }

  private IEnumerator Jump()
  {
    bool isGroundAbandoned = false;
    bool isExit = false;

    _rigidbody2D.velocity = transform.up * _jumpForce;

    while (!isExit)
    {
      transform.Translate(Vector3.right * Speed * Time.deltaTime);
      bool isOnGround = Physics2D.Raycast(_groundCheck.position, Vector2.down, 0.01f, _whatIsGround);

      if (!isOnGround)
        isGroundAbandoned = true;

      if (isGroundAbandoned && isOnGround)
        isExit = true;

      yield return null;
    }

    IsEndJump = true;
  }
}
