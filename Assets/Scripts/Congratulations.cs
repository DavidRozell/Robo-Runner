using System; // needed so it can implement the Wait()
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Congratulations : MonoBehaviour {


// Implements Wait()	
public void Wait(float seconds, Action action){
     StartCoroutine(_wait(seconds, action));
 }
 IEnumerator _wait(float time, Action callback){
     yield return new WaitForSeconds(time);
     callback();
 }	
//---------------------------------------------
	
	public AudioSource MusicSource1;
	public AudioSource MusicSource2;
	
	public AnimationClip dab;
	public AnimationClip run;
    Animation anim;
	
	AudioSource BackgroundAudioSource;
	
	void Start () {
	
	anim = gameObject.GetComponent<Animation>();
	
	}
	
	void OnCollisionEnter(Collision col) {
		
			
			if (col.gameObject.name == "EndWall3")
			{
			MusicSource2.Stop();
			MusicSource1.Play();
			Wait (2.2f, () => {
			anim.clip = dab;
            anim.Play();
			});
			Wait (4.5f, () => {
			Application.Quit();
			});
				
			}
		
		}
	
	}
