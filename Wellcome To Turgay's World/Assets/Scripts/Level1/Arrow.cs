using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class Arrow : MonoBehaviour
{
    public GameObject target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
       // transform.rotation = Quaternion.RotateTowards(transform.rotation, Rotation(), 10 * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(Direction(), Vector3.up); 
    }

    private Vector3 Direction()
    {
        Vector3 tempraryDirection = target.transform.position - transform.position;
       // tempraryDirection.z = tempraryDirection.y;
        tempraryDirection.y = 0;
        return tempraryDirection;
    }
   
}

