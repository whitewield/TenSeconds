using UnityEngine;
using System.Collections;

public class CS_Bird : MonoBehaviour {
	private int myTool;
	private Animator myAnimator;
	private Transform myPlayerTransform;
	// Use this for initialization
	void Start () {
		myAnimator = GetComponent<Animator> ();
		myPlayerTransform = GameObject.FindWithTag (CS_Global.TAG_PLAYER).transform;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateMove ();
	}

	private void UpdateMove () {
		Vector3 targetPosition = myPlayerTransform.position + Vector3.up * 0.5f;

		//if distance too long, move
		if (Vector3.Distance (this.transform.position, targetPosition) > CS_Global.DISTANCE_BIRD)
			this.transform.position = Vector3.Lerp (this.transform.position, targetPosition, Time.deltaTime);

		//set direction
		if (targetPosition.x < this.transform.position.x)
			this.transform.rotation = Quaternion.Euler (0, 180, 0);
		else this.transform.rotation = Quaternion.Euler (0, 0, 0);
	}

	public void PickUpTool () {
		if (GameObject.FindGameObjectWithTag (CS_Global.NAME_PLAYER).GetComponent<CS_PlayerControl> ().GetIsDead () == true)
			return;
		myTool = GameObject.Find (CS_Global.NAME_PLAYERPOCKRT).GetComponent<CS_PlayerPocket> ().SwitchTool (myTool);
		//myTool = t_tool;
		UpdateAnimator ();
	}

	public void UpdateAnimator () {
		//pass the value to AnimationController (update each frame)
		myAnimator.SetInteger ("myTool", myTool);
	}
}
