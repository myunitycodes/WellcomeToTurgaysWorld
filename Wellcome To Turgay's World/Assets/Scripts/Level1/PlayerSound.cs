using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class Player
{
    AudioSource audioSourcePlayer;
    AudioSource audioSourceCamera;

    [SerializeField] AudioClip gas;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip coin;
    [SerializeField] AudioClip gold;
    [SerializeField] AudioClip spin;

    void SoundControl()
    {
        audioSourcePlayer.pitch = 1+ velocity.magnitude/10; //Ilk pitch degerini 1 aldim uzerine hiz kadar ilave edecek.
    }

}
