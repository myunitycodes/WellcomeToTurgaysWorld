using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class Player
{
    IEnumerator CoRotate(InputAction.CallbackContext contex)
    {
        if (contex.ReadValue<Vector2>().x > 0)
        {
            rotateAngle = Mathf.Lerp(rotateAngle, rotateSpeed,  0.1f);

            Debug.Log(" x > 0  ");
        }
        if (contex.ReadValue<Vector2>().x < 0)
        {
            rotateAngle = Mathf.Lerp(rotateAngle, -rotateSpeed, 0.1f);
            Debug.Log(" x < 0  ");
        }

        rotateValue = contex.ReadValue<Vector2>().x;

        yield return null;
    }

    IEnumerator CoSlowDown()
    {
        currentMaxMoveSpeed = maxMoveSpeed / 2;
        yield return new WaitForSeconds(0.2f);
        currentMaxMoveSpeed = maxMoveSpeed;
    }

}
