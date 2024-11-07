using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class GameOverState : MonoBehaviour
    {
        public GameObject rootUI;
        public MainMenuState mainMenuState;
        public GamePlayState gamePlayState;

        private void OnEnable()
        {
            // Включаем rootUI, если оно не было включено ранее
            if (rootUI != null)
            {
                rootUI.SetActive(true);
            }
        }

        private void OnDisable()
        {
            // Проверяем, существует ли rootUI перед его деактивацией
            if (rootUI != null)
            {
                rootUI.SetActive(false);
            }
        }

        // Метод для перезапуска игры
        public void Restart()
        {
            // Деактивируем текущий объект и активируем gamePlayState
            // Если вы хотите скрыть UI root, делайте это здесь
            gamePlayState.gameObject.SetActive(true); // Активируем игру
            gameObject.SetActive(false); // Деактивируем текущий объект (UI, если он тут)
        }

        // Метод для возвращения в главное меню
        public void BackToMainMenu()
        {
            // Деактивируем текущий UI и активируем MainMenu
            gameObject.SetActive(false); // Деактивируем текущий объект
            mainMenuState.gameObject.SetActive(true); // Активируем главное меню
        }
    }
}
