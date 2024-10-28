using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sun : MonoBehaviour
{
    public float rotation;
    public Transform liht;
    // Start is called before the first frame update
    void Start()
    {
       rotation = 0.003f; 
    }

    // Update is called once per frame
    void Update()
    {
        liht.Rotate(rotation * new Vector3(0, 1, 0));
    }
}
