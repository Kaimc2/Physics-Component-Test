using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            videoPlayer.Play();
        }
    }
}
