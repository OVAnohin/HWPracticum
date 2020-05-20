using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
  [SerializeField] private List<Transition> _transitions;

  public Player player { get; set; }

  public void Enter(Player target)
  {

  }

}
