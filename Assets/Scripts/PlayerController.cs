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
        public float speed = 1f * 100;

        private bool isMoseHeld = false;

        private void Update()
        {
            Vector3 angle = stick.localEulerAngles;
            if (Input.GetMouseButton(0))
            {
                angle.z += speed * Time.deltaTime;
                if (angle.z > maxAngle)
                {
                    angle.z = maxAngle;
                }
            }
            else
            {
                if (angle.z > 0)
                {
                    angle.z -= speed * Time.deltaTime;
                    if (angle.z < 0) angle.z = 0;
                }
                else if (angle.z < 0)
                {
                    angle.z += speed * Time.deltaTime;
                    if (angle.z > 0) angle.z = 0;
                }
            }

        }
    }
}
