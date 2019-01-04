using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float bulletSpeed = 10.0f;
	bool facingRight;
	GameObject GameManager;
	Enemy_Spawner Enemy_Spawner;
	
	// Use this for initialization
	void Start () {
		GameManager = GameObject.Find ("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
  	}

	void OnCollisionEnter2D (Collision2D other) {
		Debug.Log ("Collision");
		if (other.transform.tag == "Enemy") {	
			Enemy_Spawner = GameManager.GetComponent<Enemy_Spawner>();
			Enemy_Spawner.ScoreUp(5);
			Destroy (other.gameObject, 0f);
			Destroy (this.gameObject);
		}
	}
}
