using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
  [SerializeField] List<Wave> _waves;
  [SerializeField] Transform _spawnPoint;
  [SerializeField] Player _target;

  private Wave _currentWave;
  private int _currentWaveNumber;
  private float _timeAfterLastSpawn;
  private int _spawned;


  private void Start()
  {

  }

  private void Update()
  {

  }

  private void SetWave(int index)
  {
    _currentWave = _waves[index];
  }
}

[System.Serializable]
public class Wave
{
  public GameObject Template;
  public float Delay;
  public int Count;
}
