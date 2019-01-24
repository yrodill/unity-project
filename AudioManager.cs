using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioSource m_soundStream;
    public AudioSource m_musicStream;

    public void PlaySound(AudioClip soundClipToPlay) {
        m_soundStream.clip = soundClipToPlay;
        m_soundStream.Play();
    }



    public static AudioManager instance = null;
    void Awake(){
        if (instance == null) {
            instance = this; DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
