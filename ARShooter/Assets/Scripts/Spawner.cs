using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
  // тут у нас 3Д
  // поэтому типа вокруг нас сфера, и по этой сфере мы уже спауним.
  [SerializeField] private float _spawnRadius;
  [SerializeField] private float _secondsBetweenSpawn;
  [SerializeField] private Enemy[] _enemys; // набор префабов врагов
  [SerializeField] private Player _target; // это вы, т.е куда монстры будут смотреть.Нужно для точки куда смотреть.

  private void Start()
  {
    StartCoroutine(SpawnRandomEnemy());
  }

  // корутина по спауну рандомных врагов
  private IEnumerator SpawnRandomEnemy()
  {
    while (true)
    {
      Enemy newEnemy = Instantiate(_enemys[Random.Range(0, _enemys.Length)], GetRandomPlaceInSphere(_spawnRadius),Quaternion.identity);
      Vector3 lookDirection = _target.transform.position - newEnemy.transform.position;
      // и теперь нашему врагу присваиваем этот поворот
      newEnemy.transform.rotation = Quaternion.LookRotation(lookDirection);
      newEnemy.EnemyDied += OnEnemyDied;

      yield return new WaitForSeconds(_secondsBetweenSpawn);
    }
  }

  private void OnEnemyDied(Enemy enemy)
  {
    enemy.EnemyDied -= OnEnemyDied;
    _target.AddScore();
  }

  // это место генерации врага
  private Vector3 GetRandomPlaceInSphere(float radius)
  {
    // тут наш метод вернет нам рандомную точку в заданном радиусе
    return Random.insideUnitSphere * radius;
  }
}
