using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BagroundMusic : MonoBehaviour {

    GameObject soundObject;
    AudioSource audioSource;
    GameObject imgObject;
    Image img;

    void Start()
    {
        soundObject = GameObject.Find("BackgrounMusicAudioSource");
        audioSource = soundObject.GetComponent<AudioSource>();
        imgObject = GameObject.Find("MuteImage");

        imgObject.transform.localScale = new Vector3(0, 0, 0);
        audioSource.Play();
    }


    // Use this for initialization
    public void BackgroundSoundOff()
    {
        soundObject = GameObject.Find("BackgrounMusicAudioSource");
        audioSource = soundObject.GetComponent<AudioSource>();
        imgObject = GameObject.Find("MuteImage");
        img = imgObject.GetComponent<Image>();

        if (audioSource.isPlaying)
        {
            imgObject.transform.localScale = new Vector3(1, 1, 1);
            audioSource.Stop();
        }
        else
        {
            imgObject.transform.localScale = new Vector3(0, 0, 0);
            audioSource.Play();
           
        }
        
    }
}
