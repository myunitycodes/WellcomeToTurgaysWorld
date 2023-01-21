using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class Player
{
    bool canInput = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "JumpStartPoint")
        {
            canInput = false;
        }

        if (other.tag == "JumpFinishPoint")
        {
            canInput = true;
        }

        if (other.gameObject.tag == "Gold")
        {
            UpdateGoldNumberCollider();
        }
        if (other.gameObject.tag == "Finish")
        {
            finishPanel.SetActive(true);
            canInput = false;
            PlayerPrefs.SetInt("Level"+(levelNumber+1),0);//Falce
            PlayerPrefs.SetInt("BtnLevel" + (levelNumber+1),1);//True
        }
         if (other.gameObject.tag == "X")
        {
            var tallAmount =Int32.Parse(other.gameObject.GetComponentInChildren<TextMeshPro>().text) ;
            var newX= transform.localScale.x + transform.localScale.x * tallAmount / 100;
            transform.DOScaleX(newX,0.5f).SetEase(Ease.InElastic);
           
        } 
        if (other.gameObject.tag == "Y")
        {
            var tallAmount =Int32.Parse(other.gameObject.GetComponentInChildren<TextMeshPro>().text) ;
            var newY = transform.localScale.y + transform.localScale.y * tallAmount / 100;
            transform.DOScaleY(newY, 0.5f).SetEase(Ease.InElastic);
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Coin")
        {
            StartCoroutine(CoSlowDown());
        }
    }

}
