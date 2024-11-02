using UnityEngine;
using UnityEngine.PlayerLoop;

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

        public Vector3 LastPointPosition { get => m_lastPointPosition; set => m_lastPointPosition = value; }

        private void Awake()
        {
            m_rigidbody = GetComponent<Rigidbody>();
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
            m_dir = (point.position - LastPointPosition).normalized;
            LastPointPosition = point.position;            
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
                var contact = other.contacts[0];
                other.rigidbody.AddForce(m_dir * power, ForceMode.Impulse);
                onCollisionStone?.Invoke();
            }
        }
    }
}