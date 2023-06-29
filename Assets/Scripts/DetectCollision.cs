using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour {


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
	public AnimationClip malfunction;
    Animation anim;
	
	void Start () {
	
	MusicSource1.clip = MusicClip1;
	MusicSource2.clip = MusicClip2;
	anim = gameObject.GetComponent<Animation>();
	
	}
	
	void OnCollisionEnter(Collision col) {
		
		
			if (col.gameObject.name == "Obstacle")
			{
			
			transform.position = new Vector3(13.555f,0.76f,-43.20501f);
			MusicSource1.Play();
			anim.clip = malfunction;
            anim.Play();
			Wait (0.6f, () => {
			anim.clip = run;
            anim.Play();
			});
			}
			
			if (col.gameObject.name == "Obstacle2")
			{
			
			transform.position = new Vector3(621.56f,0.76f,-43.20501f);
			MusicSource1.Play();
			anim.clip = malfunction;
            anim.Play();
			Wait (0.6f, () => {
			anim.clip = run;
            anim.Play();
			});
			}
			
			if (col.gameObject.name == "Obstacle3")
			{
			
			transform.position = new Vector3(1411.86f,0.76f,-43.20501f);
			MusicSource1.Play();
			anim.clip = malfunction;
            anim.Play();
			Wait (0.6f, () => {
			anim.clip = run;
            anim.Play();
			});
			}
			
			if (col.gameObject.name == "EndWall")
			{
			transform.position = new Vector3(621.56f,0.76f,-43.20501f);
			MusicSource2.Play();
			}
			
			if (col.gameObject.name == "EndWall2")
			{
			transform.position = new Vector3(1411.86f,0.76f,-43.20501f);
			MusicSource2.Play();
			}
			
			if (col.gameObject.name == "EndWall3")
			{
			transform.position = new Vector3(2602f,0.76f,-43.20501f);	
			}
			
			if (col.gameObject.name == "LeftWall")
			{
			
			GetComponent<Rigidbody> ().AddForce (Vector3.right * 10);
			}
			
			if (col.gameObject.name == "RightWall")
			{
			
			GetComponent<Rigidbody> ().AddForce (Vector3.left * 10);
			}
		
		}
	
	}
