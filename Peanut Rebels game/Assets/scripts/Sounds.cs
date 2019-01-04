using UnityEngine;
using System.Collections;

public class Sounds : MonoBehaviour {

	int startCountDown = 2;
	AudioSource sounds;
	
	// Use this for initialization
	void Start () {
		sounds = transform.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		startCountDown -= 1;
		if (startCountDown < 0){
			if(sounds.isPlaying == false){
				Destroy(this.gameObject,.0f);
			}
		}		
	}
}