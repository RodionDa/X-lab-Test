using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        public Stick stick;
        public StoneSpawner stoneSpawner;
        private float m_timer;
        [SerializeField]
        private float m_delay = 2f;
        private uint m_score = 0;

        private List<Stone> m_stones = new List<Stone>();

        public void OnEnable()
        {
            m_timer = Time.time - m_delay;
            stick.onCollisionStone += OnCollisionStick;
        }

        private void OnDisable()
        {
            if (stick)
            {
                stick.onCollisionStone -= OnCollisionStick;
            }
        }

       private void Update()
{
    if (Time.time > m_timer + m_delay)
    {
        m_timer = Time.time;

        var go = stoneSpawner.Spawn();
        if (go == null)
        {
            Debug.LogWarning("Spawn() returned null!");
            return; // Выход из метода, если объект не создан
        }

        var stone = go.GetComponent<Stone>();
        if (stone == null)
        {
            Debug.LogWarning("The spawned object does not have a Stone component!");
            return; // Выход из метода, если компонент отсутствует
        }

        stone.onCollisionStone += OnCollisionStone;
        m_stones.Add(stone);
    }
}


        private void OnCollisionStick()
        {
            m_score++; 
            Debug.Log($"score: {m_score}");
        }

        private void OnCollisionStone()
        {
            Debug.Log("GAME OVER!!!");
        }
    }
}
