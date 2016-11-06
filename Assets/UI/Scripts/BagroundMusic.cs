using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BagroundMusic : MonoBehaviour {

    // Use this for initialization
    public void BackgroundSoundOff()
    {
        GameObject soundObject = GameObject.Find("BackgrounMusicAudioSource");
        AudioSource audioSource = soundObject.GetComponent<AudioSource>();
        GameObject imgObject = GameObject.Find("MuteImage");
        Image img = imgObject.GetComponent<Image>();

        if (audioSource.isPlaying)
        {
           // img.enabled = true;
            audioSource.Stop();
        }
        else
        {
            //img.enabled = false;
            audioSource.Play();
           
        }
        
    }
}
