using UnityEngine;
using UnityEngine.UI;

public class NextWaveButton : MonoBehaviour
{
  [SerializeField] private Spawner _spawner;  // наш спаунер, куда мы отдадим команду
  [SerializeField] private Button _nextWaveButton;

  private void OnEnable()
  {
    _spawner.AllEnemySpawned += OnAllEnemySpawned; //событие окончания монстров в волне
    _nextWaveButton.onClick.AddListener(OnNextWaveButtonClick); //подписываемся на события кнопки, как нажали выполнить 
  }

  private void OnDisable()
  {
    _spawner.AllEnemySpawned -= OnAllEnemySpawned;
    _nextWaveButton.onClick.RemoveListener(OnNextWaveButtonClick); //отписываемся на события кнопки
  }

  private void OnAllEnemySpawned()
  {
    _nextWaveButton.gameObject.SetActive(true);
  }

  public void OnNextWaveButtonClick()
  {
    _spawner.NextWave();
    _nextWaveButton.gameObject.SetActive(false);
  }
}
