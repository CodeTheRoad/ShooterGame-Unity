using UnityEngine;
using System.Collections;

public class enemy_Nut : MonoBehaviour {

	public float velocity = 1f;
	public Transform sightStart;
	public Transform sightEnd;
	public bool colliding;
	GameObject GameManager;
	Enemy_Spawner Enemy_Spawner;
	
	// Use this for initialization
	void Start () {
		GameManager = GameObject.Find ("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector2 (velocity, GetComponent<Rigidbody2D>().velocity.y);
		colliding = Physics2D.Linecast (sightStart.position, sightEnd.position);

		if (colliding) {
			transform.localScale = new Vector2 (transform.localScale.x * -1, transform.localScale.y);
			velocity*= -1;
		}
	}

	void OnCollisionEnter2D (Collision2D other) {
		Debug.Log ("Collision");
		if (other.transform.tag == "Hero") {
			Destroy (other.gameObject, 0f);
            #pragma warning disable CS0618 // Type or member is obsolete
            Application.LoadLevel ("main_Menu");
            #pragma warning restore CS0618 // Type or member is obsolete
        }

        if (other.transform.tag == "Pit"){
			Enemy_Spawner = GameManager.GetComponent<Enemy_Spawner>();
			Enemy_Spawner.ScoreUp(-5);
			Destroy (this.gameObject, 0f);
		}
	}
}
