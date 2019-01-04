using UnityEngine;
using System.Collections;


public class Hero_Script : MonoBehaviour {

	public float speed = 8f;
	public Vector2 jumpVector;
	public GameObject bulletPrefab;
	public Animator Walk;
	public bool isGrounded;
	public Transform grounder;
	public float radius;
	public LayerMask ground;
    public GameObject bulletFire;
    private AudioSource gun_Fire;
	private GameObject tempBulletFire;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		isGrounded = Physics2D.OverlapCircle (grounder.transform.position, radius, ground);

		if (Input.GetKey (KeyCode.UpArrow) && isGrounded == true){
			GetComponent<Rigidbody2D> ().AddForce (jumpVector, ForceMode2D.Force);
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			transform.Translate(Vector2.right * speed * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 0);
			Walk.SetBool("Hero_Walking", true);
		}
		else {
			Walk.SetBool("Hero_Walking", false);
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			transform.Translate(Vector2.right * speed * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 180);
			Walk.SetBool("Hero_Walking", true);
		}
		else {
			Walk.SetBool("Hero_Walking", false);
		}
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            tempBulletFire = Instantiate(bulletFire, transform.position, transform.rotation) as GameObject;
            gun_Fire = tempBulletFire.GetComponent<AudioSource>();
            gun_Fire.Play();
        }
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere (grounder.transform.position, radius);
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.transform.tag == "Pit"){
			Destroy (this.gameObject, 0f);
            #pragma warning disable CS0618 // Type or member is obsolete
            Application.LoadLevel ("main_Menu");
            #pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}
