using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// скрипт вешаем на shop
public class Menu : MonoBehaviour
{
  // эти методы вешаем из unity через события, руками
  public void OpenPanel(GameObject panel)
  {
    panel.SetActive(true); //панель становится активной
    Time.timeScale = 0; // остановка времени 
  }

  // эти методы вешаем из unity через события, руками
  // тут выбираем canvas -> событие ClosePanel -> и закрыть наш shop
  public void ClosePanel(GameObject panel)
  {
    panel.SetActive(false); //панель становится активной
    Time.timeScale = 1; // запускаем время снова
  }

  public void Exit()
  {
    Application.Quit(); //выход из игры
  }
}
