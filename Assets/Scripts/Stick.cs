using UnityEngine;

namespace Golf
{
    public class Stick : MonoBehaviour
    {
        public float maxAngle = 30f;
        public float speed = 360f;
        public float power = 100f;
        public Transform point;
        public event System.Action onCollisionStone;

        private Vector3 m_lastPointPosition;
        private Vector3 m_dir;
        private bool m_isDown = false;
        private Rigidbody m_rigidbody;

        private void Awake()
        {
            m_rigidbody = GetComponent<Rigidbody>();
            m_lastPointPosition = point.position; // Инициализируем начальную позицию
        }

        public void Down()
        {
            m_isDown = false;
        }

        public void Up()
        {
            m_isDown = true;
        }

        private void Update()
        {
            m_dir = (point.position - m_lastPointPosition).normalized;
            m_lastPointPosition = point.position;            
        }

        private void FixedUpdate()
        {
            Vector3 angle = transform.localEulerAngles;
            if (m_isDown)
            {   
                angle.z = Mathf.MoveTowardsAngle(angle.z, -maxAngle, speed * Time.deltaTime);
            }
            else
            {
                angle.z = Mathf.MoveTowardsAngle(angle.z, maxAngle, speed * Time.deltaTime);
            }
            transform.localEulerAngles = angle;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent<Stone>(out var stone) && !stone.isDirty)
            {
                stone.isDirty = true;

                // Проверка скорости палки
                //float speedMagnitude = m_rigidbody.velocity.magnitude; // Получаем скорость палки

                //if (speedMagnitude > 100f) // Установите порог, например 1f
                {
                    // Используем направление вперёд для силы
                    Vector3 launchDirection = transform.forward; // Направление вперёд от палки
                    other.rigidbody.AddForce(launchDirection * power, ForceMode.Impulse);
                }

                onCollisionStone?.Invoke();
            }
        }
    }
}
