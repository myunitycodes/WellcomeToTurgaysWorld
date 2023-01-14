using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    float lifeTime;
   // Rigidbody rb;   
    private void Start()
    {
        lifeTime = GameObject.FindObjectOfType<Car>().lifeTime;
       // rb=GetComponent<Rigidbody>();   
    }
    private void OnEnable()
    {
       // rb.AddForce(-transform.forward);
         Invoke("Inactive",lifeTime);
    }
  
    void Inactive()
    {
        gameObject.SetActive(false);    
    }
    
}
