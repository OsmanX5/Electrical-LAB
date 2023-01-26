using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsLibrary : MonoBehaviour
{
    public AudioClip _buttonClick;
    public AudioClip _fastClick;
    public AudioClip _Collect;
    public AudioClip _Electricity;
    public AudioClip _disapper;


    public static AudioClip buttonClick;
    public static AudioClip fastClick;
    public static AudioClip Collect;
    public static AudioClip Electricity;
    public static AudioClip disapper;
    private void Start()
    {
        buttonClick = _buttonClick;
        fastClick = _fastClick;
        Collect = _Collect;
        Electricity = _Electricity;
        disapper = _disapper;
    }

}
