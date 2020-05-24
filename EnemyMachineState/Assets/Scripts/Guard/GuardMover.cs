using UnityEngine;

[RequireComponent(typeof(GuardSearchTarget))]
public class GuardMover : State
{
  private System.Random rand = new System.Random();

  private void OnEnable()
  {
    if (!GetComponent<GuardSearchTarget>().IsTargetFound)
    {
      if (rand.Next(0, 2) == 1)
        transform.eulerAngles = new Vector3(0, -180, 0);
      else
        transform.eulerAngles = new Vector3(0, 0, 0);
    }
  }

  private void Update()
  {
    transform.Translate(Vector3.right * Speed * Time.deltaTime);
  }
}
