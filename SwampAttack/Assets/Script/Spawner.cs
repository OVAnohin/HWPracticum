using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
  [SerializeField] private Player _player; // наша цель, для инициализации префабов в волне
  [SerializeField] private List<Wave> _waves; // коллекция наших волн
  [SerializeField] private Transform _spawnPoint; // точка спавна, если захотим поменять

  private Wave _currentWave;						// текушая волна
  private int _currentWaveNumber = 0;   // номер волны, текущей
  private float _timeAfterLastSpawn;		// время прошедшее от последней волны
  private int _spawned; // количество врагов которых спаунили в волне

  public UnityAction<int, int> EnemySpawnChanged; // событие для кнопки, или ещё чего, в нашем случае для включения слудующей волны
  public event UnityAction AllEnemySpawned; //событие говорит что враги в волне закончены

  private void Start()
  {
  	// устанавливаем новую волну, в нашем случае первую
    SetWave(_currentWaveNumber);
    EnemySpawnChanged(0, 1);
  }

  private void Update()
  {
  	//случай когда волн нет, или они уже кончились
    if (_currentWave == null)
      return;

		//считаем наше время последнего спауна монстра
    _timeAfterLastSpawn += Time.deltaTime;

		//если время прошедшее больше задержки, то мы можем создавать из спауна монстра
    if (_timeAfterLastSpawn >= _currentWave.Delay)
    {
    	// 1. в спавн входит создание монстра
    	// 2. установка что мы создали монстра
    	// 3. нам нужно подписаться на событе что монстр умирает
    	// что бы забрать награду от монстра и всё это мы выносим в InstantiateEnemy();
      InstantiateEnemy();
      _spawned++;
      EnemySpawnChanged(_spawned, _currentWave.Count);
      _timeAfterLastSpawn = 0;
    }
 		//проверка на количество монстров в данном спауне 
    if (_currentWave.Count <= _spawned)
    {
    	// если у нас волн ещё хватает?
      if (_waves.Count > _currentWaveNumber + 1)
      {
        if (AllEnemySpawned != null)
          AllEnemySpawned?.Invoke(); //говорим миру что враги кончились в этой волне
      }

      _currentWave = null;
    }
  }

  // создание монстра из волны
  private void InstantiateEnemy()
  {
  	// получаем монстра из волны
    Enemy enemy = Instantiate(_currentWave.Template, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint).GetComponent<Enemy>();
    // инициируем 
    enemy.Init(_player);
    // подписываемся на событие смерти, для этого специально сделали метод OnEnemyDying(Enemy enemy)
    // что бы в нем отписаться
    enemy.Dying += OnEnemyDying; // подписался, обязательно отпишись
  }

  public void NextWave()
  {
    EnemySpawnChanged(0, 1);
    SetWave(++_currentWaveNumber);
    _spawned = 0;
  }

  // установка волны, номер какой мы хотим установить
  private void SetWave(int index)
  {
    _currentWave = _waves[index];
  }

// метод специально для обработки события смерти монстра
  private void OnEnemyDying(Enemy enemy) // мы принимаем того монстра, который умирает, он больше не нужен и отпишемся от него
  {
    enemy.Dying -= OnEnemyDying; // подписался, обязательно отпишись
    _player.AddMoney(enemy.Reward);
  }
}

[System.Serializable] // не забудь для отображения в инспекторе
public class Wave
{
  public GameObject Template; //наш враг
  public float Delay; // время между выходом врагов в волне
  public int Count;  // общее количество врагов
}