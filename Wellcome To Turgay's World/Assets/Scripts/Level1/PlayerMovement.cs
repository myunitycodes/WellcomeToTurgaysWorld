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
            //wheel1.transform.Rotate(new Vector3(30 * velocity.magnitude, 0, 0));
            //wheel2.transform.Rotate(new Vector3(30 * velocity.magnitude, 0, 0));
            //wheel3.transform.Rotate(new Vector3(30 * velocity.magnitude, 0, 0));
            //wheel4.transform.Rotate(new Vector3(30 * velocity.magnitude, 0, 0));
            
            wheel1.transform.Rotate(Vector3.right, 30 * velocity.magnitude);
            wheel2.transform.Rotate(Vector3.right, 30 * velocity.magnitude);
            wheel3.transform.Rotate(-Vector3.right, 30 * velocity.magnitude);
            wheel4.transform.Rotate(Vector3.right, 30 * velocity.magnitude);

            


        }

        // rb.MovePosition(rb.position + transform.forward * Time.fixedTime / 100);

    }

    private void Rotate()
    {

        if (stopRotate) rotateAngle = Mathf.Lerp(rotateAngle, 0, 3 * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, rotateAngle, 0));
        //if (canInput && isTappedStart)
        //{
        //    if (!isTriggeredSwipe && isMoving) rotateAngle = Mathf.Lerp(rotateAngle, 0, 3 * Time.fixedDeltaTime);
        //    rb.MoveRotation(Quaternion.Euler(0, rotateAngle, 0));
        //}


        //wheel1.transform.DORotate(new Vector3(0, 45*Mathf.Abs(rotateValue), 0), 0.5f);//DORotate(Buraya girilen vector her bir eksenin hedefi oluyor)
        wheel1Parent.transform.localRotation = Quaternion.Euler(0, 30 * Mathf.Sign(rotateAngle) * velocity.magnitude, 0);
        wheel2Parent.transform.localRotation= Quaternion.Euler(0, 30 * Mathf.Sign(rotateAngle) * velocity.magnitude, 0);



    }

}
