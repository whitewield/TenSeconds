using UnityEngine;
using System.Collections;

public class CS_Ghost : MonoBehaviour {
	public bool onMove = false;
	public Vector3 myPos1;
	public Vector3 myPos2;
	private Vector3 nextPos;

	public float speed = 1.0f;
	public float waitTime = 1.0f;
	private float timer = 0;

	// Use this for initialization
	void Start () {
		nextPos = myPos1;
	}

	// Update is called once per frame
	void Update () {
		if (onMove)
			UpdateMove ();
	}

	private void UpdateMove () {
		if (timer > 0) {

			timer -= Time.deltaTime;
			return;
		}

		if (Vector3.Distance(nextPos, transform.position) <= speed * Time.deltaTime) {
			//stop walking
			nextPos = myPos1 + myPos2 - nextPos;
			timer = waitTime;
			return;
		}

		//set the speed of the player
		Vector3 translation = (nextPos - transform.position).normalized * speed * Time.deltaTime;

		//Debug.Log ("Move:" + translation);
		transform.position += translation;

		//change the directionof the player if he turns
		if (translation.x > 0) {
			transform.rotation = Quaternion.Euler(0, 180, 0);
		} else if (translation.x < 0) {
			transform.rotation = Quaternion.Euler(0, 0, 0);
		}
	}

	public void Disappear () {
		GetComponent<Animator> ().SetTrigger ("Disappear");
		onMove = false;
	}

	public void KillMyself () {
		Destroy (this.gameObject);
	}
}