using System;
using System.Collections;
using System.Collections.Generic;
using Golf;
using UnityEngine;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        public Stick stick;
        public StoneSpawner stoneSpawner;
        private float m_timer;

        [SerializeField]
        private float m_initialDelay = 2f; // Начальная задержка (в секундах)
        private float m_delay; // Текущая задержка
        private int m_score = 0;

        private List<Stone> m_stones = new List<Stone>();

        public event Action<int> onGameOver;
        public event Action<int> onScoreInc;

        private void OnEnable()
        {
            m_delay = m_initialDelay; // Инициализируем текущую задержку как начальную
            m_timer = Time.time - m_delay;
            stick.onCollisionStone += OnCollisionStick;

            m_score = 0;
            ClearStones();
        }

        private void OnDisable()
        {
            if (stick)
            {
                stick.onCollisionStone -= OnCollisionStick;
            }
        }

        private void ClearStones()
        {
            foreach (var stone in m_stones)
            {
                Destroy(stone.gameObject);
            }

            m_stones.Clear();
        }

        private void Update()
        {
            // Проверка времени, чтобы спавнить камни с учётом текущей задержки
            if (Time.time > m_timer + m_delay)
            {
                m_timer = Time.time;

                // Спавним камень
                var go = stoneSpawner.Spawn();
                var stone = go.GetComponent<Stone>();

                // Подписываемся на событие столкновения с камнем
                stone.onCollisionStone += OnCollisionStone;

                // Добавляем камень в список
                m_stones.Add(stone);

                // Проверяем, нужно ли уменьшить задержку
                AdjustSpawnSpeed();
            }
        }

        private void OnCollisionStick()
        {
            m_score++;
            Debug.Log($"score: {m_score}");
            onScoreInc?.Invoke(m_score);
        }

        private void OnCollisionStone()
        {
            Debug.Log("GAME OVER!!!");
            onGameOver?.Invoke(m_score);
        }

        // Метод для увеличения скорости спавна
        private void AdjustSpawnSpeed()
        {
            // Уменьшаем задержку только после достижения 10, 20, 30 и т.д. очков
            if (m_score >= 10 && m_score % 10 == 0)
            {
                // Уменьшаем задержку в 2 раза (ускоряем спавн)
                float oldDelay = m_delay; // Сохраняем старую задержку

                // Уменьшаем задержку в два раза
                m_delay /= 2f;

                // Ограничиваем минимальную задержку (например, 0.5 секунд)
                m_delay = Mathf.Max(m_delay, 0.5f);

                // Выводим информацию о старой и новой задержке
                if (oldDelay != m_delay) // Выводим только если задержка изменилась
                {
                    Debug.Log($"Spawn speed increased! Old delay: {oldDelay:F2}s, New delay: {m_delay:F2}s");
                }
            }
        }
    }
}
