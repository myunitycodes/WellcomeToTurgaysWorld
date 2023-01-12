using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotateSpeed;
        private void Update()
    {
        transform.Rotate(Vector3.up*5);
    }
}
