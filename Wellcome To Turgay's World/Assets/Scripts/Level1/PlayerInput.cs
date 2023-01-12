using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class Player
{
    bool isTriggeredSwipe;
   
    Sequence sequence;
   public void InputHold(InputAction.CallbackContext contex)
    {
        if (contex.performed)
        {
            sequence.Kill();
            isMoving = true;
             }

        if (contex.canceled)
        {
           
            sequence = DOTween.Sequence();
           sequence.Append(DOTween.To(() => velocity, x => velocity = x, Vector3.zero, 1f).OnComplete(() => isMoving = false)) ;
            StopCoroutine(CoRotate(contex));
            
        }

    }


    public void InputSwipe(InputAction.CallbackContext contex)
    {
        if (contex.started)
        {
            stopRotate = false;
            StartCoroutine(CoRotate(contex));
           // isTriggeredSwipe = true;// Yeniden Tap edene kadar true kalmali ki Delta==0 durumlarinda hemen ileriye donme eylemi gerceklesmesin.Ileriye donme eylemi ilk dokunusta delta 0 dan farkli olana kadar gerceklessin. 
        }

        if (contex.canceled)
        {
            stopRotate = true;
            //StopCoroutine(CoRotate(contex));

        }
    }

    public void InputTap(InputAction.CallbackContext contex)
    {
        if (contex.started)
        {
            isMoving = true; isTriggeredSwipe = false;//Yeniden Tap olana kadar true da tutuldu. 
        }
        if (contex.canceled) isMoving = false;
    }
}
