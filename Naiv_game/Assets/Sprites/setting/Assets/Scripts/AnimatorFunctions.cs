using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorFunctions : MonoBehaviour
{
	[SerializeField] MenuButtonController menuButtonController;
    public AudioClip musicClip;
    public AudioSource MusicSource; 
     
    public start()
    {
        MusicSource.clip = MusicSource;

    }
	public bool disableOnce;

	void PlaySound(AudioClip whichSound){
		//if(!disableOnce){
			menuButtonController.audioSource.PlayOneShot (whichSound);
		//}else{
		//	disableOnce = false;
		//}
	}
}	
