using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEndGame : MonoBehaviour
{
    public AudioClip audioEnd;
    public Transform mainCamera;

    private void OnEnable() {
        this.EnableAudio();
    }

    protected void EnableAudio()
    {
        AudioSource.PlayClipAtPoint(this.audioEnd, this.mainCamera.position, 1.0f);
    }
}
