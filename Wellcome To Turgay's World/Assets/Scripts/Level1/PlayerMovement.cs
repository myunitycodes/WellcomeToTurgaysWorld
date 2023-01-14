using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class Player
{
    float rotateAngle;
    bool isMoving;

    Vector3 velocity;
    public float acceleration;
    public float maxMoveSpeed;
    public float currentMaxMoveSpeed;
    public float rotateSpeed;
    public float traction;
    bool stopRotate;
    [SerializeField] GameObject wheel1;
    [SerializeField] GameObject wheel2;
    [SerializeField] GameObject wheel3;
    [SerializeField] GameObject wheel4;
    [SerializeField] GameObject wheel1Parent;
    [SerializeField] GameObject wheel2Parent;
    float wheelRotateAngle;

    float rotateValue;//contex.ReadValue<Vector2>().x dan deger almak icin kullaniliyor
    void Movement()
    {
        if (isMoving)
        {
            velocity += transform.forward * acceleration * Time.deltaTime;
            velocity = velocity.magnitude * Vector3.Lerp(velocity.normalized, transform.forward, traction * Time.fixedDeltaTime);//Traction  cekis gucu kandirmacasi veriyor.
            velocity = Vector3.ClampMagnitude(velocity, currentMaxMoveSpeed);
            rb.MovePosition(transform.position + velocity * Time.deltaTime);



            //Tekerleri ileri ve sag sola dondurmek icin. Sagsola dondurmek icin inputactiondan veri alip onu y eksenine atadim
            wheel1.transform.Rotate(Vector3.right, 30 * velocity.magnitude);         
            wheel2.transform.Rotate(Vector3.right, 30 * velocity.magnitude);         
            wheel3.transform.Rotate(-Vector3.right, 30 * velocity.magnitude);          
            wheel4.transform.Rotate(Vector3.right, 30 * velocity.magnitude);
      
        }

        

    }

    private void Rotate()
    {

        if (stopRotate) rotateAngle = Mathf.Lerp(rotateAngle, 0, 3 * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, rotateAngle, 0));


        wheelRotateAngle= 30 * rotateAngle * velocity.magnitude;
        wheelRotateAngle = Mathf.Clamp(wheelRotateAngle,-30,30);
        wheel1Parent.transform.localRotation = Quaternion.Euler(0,wheelRotateAngle , 0);
        wheel2Parent.transform.localRotation= Quaternion.Euler(0,wheelRotateAngle, 0);



    }

}
