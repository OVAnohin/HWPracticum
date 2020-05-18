using UnityEngine;

public class Spawner : ObjectPool
{
  [SerializeField] private Enemy[] _enemyPrefabs;
  [SerializeField] private Transform[] _spawnPoints;
  [SerializeField] private float _secondsBetweenSpawn;

  private float _elapsedTime = 0;
  private System.Random rand = new System.Random();

  private void Start()
  {
    GameObject[] element = new GameObject[_enemyPrefabs.Length]; 
    for (int i = 0; i < _enemyPrefabs.Length; i++)
    {
      element[i] = _enemyPrefabs[i].gameObject;
    }
    Initialize(element);
  }

  private void Update()
  {
    _elapsedTime += Time.deltaTime;

    if (_elapsedTime >= _secondsBetweenSpawn)
    {
      if (TryGetObject(out GameObject element))
      {
        _elapsedTime = 0;
        int spawnPoint = rand.Next(0, _spawnPoints.Length);
        SetEnemy(element, _spawnPoints[spawnPoint].position);
      }
    }
  }

  private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
  {
    enemy.SetActive(true);
    enemy.transform.position = spawnPoint;
  }
}
