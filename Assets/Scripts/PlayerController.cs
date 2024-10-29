using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;


namespace Golf
{
    public class PlayerController : MonoBehaviour
    {
        public Transform stick;
        public float maxAngle = 30;
        public float speed = 1f;

        private void Update()
        {
            Vector3 angle = stick.localEulerAngles;
            if (Input.GetMouseButton(0))
            {
                angle.z += speed * Time.deltaTime;
                angle.z = Mathf.Min(angle);
            }
            else 
            {
                angle.z = -maxAngle;
            }
        }
    }
}
