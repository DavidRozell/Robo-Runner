using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class NewVoiceRecognition : MonoBehaviour
{
	
	
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

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    void Start()
    {
        actions.Add("jump", Jump);
		actions.Add("left", Left);
		actions.Add("right", Right);


        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
		
		
		MusicSource1.clip = MusicClip1;
		MusicSource2.clip = MusicClip2;
		
		anim = gameObject.GetComponent<Animation>();
		
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {

        Debug.Log(speech.text);
        actions[speech.text].Invoke();

    }

    private void Jump()
    {
		
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
	
	private void Left()
	{
		if ((transform.position.y <= 1.05f) && (transform.position.x < 2000f)){
		GetComponent<Rigidbody> ().velocity = new Vector3(-10, 0, 0);
		 MusicSource2.Play();
		}

	}
	
	
		private void Right()
	{
		if ((transform.position.y <= 1.05f) && (transform.position.x < 2000f)){
		GetComponent<Rigidbody> ().velocity = new Vector3(10, 0, 0);
		MusicSource2.Play();
		}
	
	}
	

}