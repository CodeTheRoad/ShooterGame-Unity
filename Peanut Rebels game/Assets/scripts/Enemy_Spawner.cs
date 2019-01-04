using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy_Spawner : MonoBehaviour {

	public GameObject Enemy;
	public float spawnTime = 5f;
	public Text scoreboard;
	public int score = 0;
	public Text highScoreBoard;
	public int highScore = 60;

	// Use this for initialization
	void Start () {
		highScore = PlayerPrefs.GetInt("highScore");
		highScoreBoard.text = "High Score: " + highScore;
		StartCoroutine (SpawnTimer ());
	}

    IEnumerator SpawnTimer(){ // Timer before spawns
        while (true){   
            Spawn();
            yield return new WaitForSeconds(2f);
            }
		}
	
	void Update (){

		if (score <= -15){
            #pragma warning disable CS0618 // Type or member is obsolete
            Application.LoadLevel ("main_Menu");
            #pragma warning restore CS0618 // Type or member is obsolete
        }
    }
	// Update is called once per frame
	void Spawn () {
			float TopScreenBound = 10;                    // set value for this
			float randomX = Random.Range(10f, -10f);
			Instantiate(Enemy, new Vector3(randomX, TopScreenBound, 0), Quaternion.identity); // Spawns in random position
	}

	public void ScoreUp (int points) {
		score += points;
		scoreboard.text = "Score: " + score;
		if(score > highScore){
			highScore = score;
			highScoreBoard.text = "High Score: " + highScore;
			PlayerPrefs.SetInt ("highScore",highScore);
		}
	}
}
