using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
  [SerializeField] private Player _player;
  [SerializeField] private List<Wave> _waves;
  [SerializeField] private Transform _spawnPoint;

  private Wave _currentWave;
  private int _currentWaveNumber = 0;
  private float _timeAfterLastSpawn;
  private int _spawned; // количество врагов которых спаунили в волне

  public UnityAction<int, int> EnemySpawnChanged;
  public event UnityAction AllEnemySpawned; //событие говорит что враги в волне закончены

  private void Start()
  {
    SetWave(_currentWaveNumber);
    EnemySpawnChanged(0, 1);
  }

  private void Update()
  {
    if (_currentWave == null)
      return;

    _timeAfterLastSpawn += Time.deltaTime;

    if (_timeAfterLastSpawn >= _currentWave.Delay)
    {
      InstantiateEnemy();
      _spawned++;
      EnemySpawnChanged(_spawned, _currentWave.Count);
      _timeAfterLastSpawn = 0;
    }

    if (_currentWave.Count <= _spawned)
    {
      if (_waves.Count > _currentWaveNumber + 1)
      {
        if (AllEnemySpawned != null)
          AllEnemySpawned(); //говорим миру что враги кончились в этой волне
      }

      _currentWave = null;
    }
  }

  private void InstantiateEnemy()
  {
    Enemy enemy = Instantiate(_currentWave.Template, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint).GetComponent<Enemy>();
    enemy.Init(_player);
    enemy.Dying += OnEnemyDying; // подписался, обязательно отпишись
  }

  public void NextWave()
  {
    EnemySpawnChanged(0, 1);
    SetWave(++_currentWaveNumber);
    _spawned = 0;
  }

  private void SetWave(int index)
  {
    _currentWave = _waves[index];
  }

  private void OnEnemyDying(Enemy enemy)
  {
    enemy.Dying -= OnEnemyDying; // подписался, обязательно отпишись
    _player.AddMoney(enemy.Reward);
  }
}

[System.Serializable]
public class Wave
{
  public GameObject Template;
  public float Delay;
  public int Count;
}