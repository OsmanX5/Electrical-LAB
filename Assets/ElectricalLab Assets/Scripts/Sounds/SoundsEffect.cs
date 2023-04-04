using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsEffects : MonoBehaviour
{
    static AudioSource Aud;
    public static void SetAudioSource(AudioSource aud) {
        Aud = aud;
    }
    public static void PlayClick()
    {
        Aud.PlayOneShot(SoundsLibrary.buttonClick);
    }
    public static void PlayFastClick()
    {
        Aud.PlayOneShot(SoundsLibrary.fastClick);
    }
    public static void PlayCollect()
    {
        Aud.PlayOneShot(SoundsLibrary.Collect);
    }
    public static void PlayDisapper()
    {
        Aud.PlayOneShot(SoundsLibrary.disapper);
    }
    public static void PointDisconnected(Point p)
    {
        Aud.PlayOneShot(SoundsLibrary.disapper);
    }
    public static void PointsConnected(Point p,Point p2)
    {
        Aud.PlayOneShot(SoundsLibrary.Collect);
    }
}
