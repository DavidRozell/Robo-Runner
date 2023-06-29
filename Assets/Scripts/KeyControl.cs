using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControl : MonoBehaviour {


// Implements Wait()	
public void Wait(float seconds, Action action){
     StartCoroutine(_wait(seconds, action));
 }
 IEnumerator _wait(float time, Action callback){
     yield return new WaitForSeconds(time);
     callback();
 }	
//---------------------------------------------


	public AudioClip MusicClip1;
	public AudioSource MusicSource1;
	
	public AudioClip MusicClip2;
	public AudioSource MusicSource2;
	
	public AnimationClip run;
	public AnimationClip jump;
    Animation anim;

	// Use this for initialization
	void Start () {
	
	MusicSource1.clip = MusicClip1;
	MusicSource2.clip = MusicClip2;
	anim = gameObject.GetComponent<Animation>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	 if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow))) {

		if ((transform.position.y <= 1.05f) && (transform.position.x < 2000f)){
		 GetComponent<Rigidbody> ().velocity = new Vector3(-10, 0, 0);
		 MusicSource2.Play();
		}
     }
		
		if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.RightArrow))) {
		
		if ((transform.position.y <= 1.05f) && (transform.position.x < 2000f)){
		GetComponent<Rigidbody> ().velocity = new Vector3(10, 0, 0);
		MusicSource2.Play();
		}
		
		}
		
		if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.UpArrow))) {
		 
		if ((transform.position.y <= 1.05f) && (transform.position.x < 2000f)){
		GetComponent<Rigidbody> ().velocity = new Vector3(0, 10, 0);
		anim.clip = jump;
		anim.Play();
		MusicSource1.Play();
			Wait (1, () => {
            anim.Stop();
			});
			Wait (2, () => {
			anim.clip = run;
            anim.Play();
			});
		}
		
		} 
		
     }
	
	
     }