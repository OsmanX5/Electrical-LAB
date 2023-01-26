using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManger : MonoBehaviour
{
    AudioSource effectsAud;
    private void Start()
    {
        effectsAud = this.GetComponent<AudioSource>();
        SoundsEffects.SetAudioSource(effectsAud);
        GameManger.GraphManger.OnConnectTwoNodes += SoundsEffects.PointsConnected;
        GameManger.GraphManger.OnPointDeleted += SoundsEffects.PointDisconnected;
    }
    
}
