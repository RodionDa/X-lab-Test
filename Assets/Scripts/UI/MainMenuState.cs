using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Подключаем TextMeshPro

namespace Golf
{
    public class MainMenuState : MonoBehaviour
    {
        public GameObject mainMenuUI;
        public GamePlayState gamePlayState;
        public TextMeshProUGUI scoreText;

        private void OnEnable()
        {
            mainMenuUI.SetActive(true);
            scoreText.text = $"TOP SCORE: {GameInstance.score}"; // Убедитесь, что GameInstance существует и имеет поле score
        }

        private void OnDisable()
        {
            mainMenuUI.SetActive(false);
        }

        public void Play()
        {
            gameObject.SetActive(false);
            gamePlayState.gameObject.SetActive(true);
        }
    }
}
