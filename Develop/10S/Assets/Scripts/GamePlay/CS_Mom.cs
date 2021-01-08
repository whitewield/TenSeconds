using UnityEngine;
using System.Collections;

public class CS_Mom : MonoBehaviour {
	public bool onMove = false;
	public float myPosX1;
	public float myPosX2;
	private float nextPosX;

	public float speed = 1.0f;
	public float waitTime = 1.0f;
	private float timer = 0;
	
	private Rigidbody myRigidbody;

	private int findDead = 0;

	// Use this for initialization
	void Start () {
		nextPosX = myPosX1;

		myRigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (findDead == 1) {
			timer -= Time.deltaTime;
			if (timer <= 0) {
				GameObject.Find (CS_Global.NAME_TRANSITIONMANAGER).SendMessage ("StartAnimationOut", "Failed");
				findDead = 2;
			}
			return;
		} else if (findDead == 2) {
			return;
		}

		if (onMove)
			UpdateMove ();
	}

	private void UpdateMove () {
		if (timer > 0) {

			timer -= Time.deltaTime;
			return;
		}

		if (Mathf.Abs (nextPosX - this.transform.position.x) <= speed) {
			//stop walking
			nextPosX = myPosX1 + myPosX2 - nextPosX;
			timer = waitTime;
			GetComponent<Animator> ().SetBool ("onWalk", false);
			return;
		}

		//set the speed of the player
		float translation = Mathf.Sign(nextPosX - this.transform.position.x) * speed;

		myRigidbody.velocity = 
			new Vector3 (translation, myRigidbody.velocity.y, 0);
		
		//change the directionof the player if he turns
		if (translation > 0) {
			transform.rotation = Quaternion.Euler(0, 180, 0);
		} else if (translation < 0) {
			transform.rotation = Quaternion.Euler(0, 0, 0);
		}

		GetComponent<Animator> ().SetBool ("onWalk", true);
	}

	void OnTriggerEnter (Collider other) {
		ColliderEnter (other.gameObject);
	}

	void OnCollisionEnter (Collision collision) {
		ColliderEnter (collision.gameObject);
	}

	private void ColliderEnter (GameObject g_GO) {
		if (g_GO.tag == CS_Global.TAG_DEADBODY) {

			onMove = false;
			GetComponent<Animator> ().SetBool ("onWalk", false);

			timer = 3.0f;
			findDead = 1;

			Camera.main.SendMessage ("FindMyMom");
		}
	}
}
