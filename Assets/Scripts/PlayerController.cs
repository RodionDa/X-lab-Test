using UnityEngine;

namespace Golf
{
     public class PlayerController : MonoBehaviour
    {
        public Stick stick;

        // private void FixedUpdate()
        // {
        //      if (Input.GetMouseButton(0))
        //      {   
        //          PointerDown();
        //      }
        //      else
        //      {
        //          PointerUp();
        //      }
        // }

        public void PointerDown()
        {
            stick.Down();
            Debug.Log("PointerDown");
        }

        public void PointerUp()
        {
            stick.Up();
            Debug.Log("PointerUp");
        }
    }

    
}