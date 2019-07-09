using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatorFunctions : MonoBehaviour
{
	[SerializeField]
    MenuButtonController menuButtonController;
    public AudioClip musicClip;
    public AudioSource MusicSource;
		public bool disableOnce;

    public void start()
    {
        MusicSource.clip = musicClip;
    }

	void PlaySound(AudioClip whichSound){
		if(!disableOnce){
		MusicSource.PlayOneShot(whichSound);
		}else{
			disableOnce = false;
		}
	}
}
