using UnityEngine;
using System.Collections;

public class CS_PlayerControl : MonoBehaviour {

	private float horizontalSpeed = CS_Global.SPEED_HORIZONTAL;
	private float jumpSpeed = CS_Global.SPEED_JUMP;
	private float speedRate;
	private Rigidbody myRigidbody;

	private Animator myAnimator;
	public GameObject myArm;
	public bool isWalking;
	private bool isGrounded;
	private bool isDead;
	private bool isGameOn;
	public int myTool;

	public GameObject myWomb;
	public GameObject myPocket;

	private bool isGravityChanged;

	private int screenMoveAxis;
	public bool onAutoMove;
	public GameObject AM_Click;
	public GameObject AM_Select;
	public Vector2 autoMoveTargetPosition;
	public GameObject autoMoveTarget;

	private Vector3 eulerRotation;

	void Start () {

		this.name = CS_Global.NAME_PLAYER;

		FindMyWomb ();
		Birth ();
		FindMyPocket ();

		myRigidbody = GetComponent<Rigidbody> ();
		myAnimator = GetComponent<Animator> ();
		if(myArm == null)Debug.LogError("Where is my arm? I can not find it...");

		isWalking = false;
		isGrounded = false;

		SetSpeedRate (CS_Global.SPEED_RATE_WALK);

		AM_Select = Instantiate (AM_Select);
		AM_Select.SetActive (false);

		eulerRotation = CS_Global.EULER_ANGLES_BL;
	}
	
	void Update () {
		UpdateGravity ();
		UpdateAutoMove ();
		UpdateMove ();
		UpdateAnimator ();
		if (myTool == 3)
			Jump ();
	}

	public void SetScreenMoveAxis (int t_direction) {
		//if (screenMoveAxis == t_direction)
		//	screenMoveAxis = 0;
		//else screenMoveAxis = t_direction;
		screenMoveAxis = t_direction;
	}

	public void SetAutoMove (GameObject g_gameObject) {
		onAutoMove = true;
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast (ray, out hit)) {
			autoMoveTargetPosition = hit.point;
			Instantiate (AM_Click, hit.point, Quaternion.identity);
		}

		//record the target object
		if (g_gameObject.tag == CS_Global.TAG_TOOL) {
			autoMoveTargetPosition = g_gameObject.transform.position;
			ClearAutoMoveTarget ();
			SetAutoMoveTarget (g_gameObject);
		} else {
			ClearAutoMoveTarget ();
		}
	}

	private void UpdateAutoMove () {
		//if (onAutoMove == true && (autoMoveTargetPosition != null)) {
		if (onAutoMove == true) {
			if (Mathf.Abs(myRigidbody.position.x - autoMoveTargetPosition.x) < CS_Global.DISTANCE_MOVE) {
				onAutoMove = false;
				screenMoveAxis = 0;
			} else {
				if (myRigidbody.position.x > autoMoveTargetPosition.x) {
					screenMoveAxis = -1;
				} else 
					screenMoveAxis = 1;
			}
		}

		if (autoMoveTarget != null)
		if (Mathf.Abs (autoMoveTarget.transform.position.x - myRigidbody.position.x) < CS_Global.DISTANCE_GET_TOOL &&
			Mathf.Abs (autoMoveTarget.transform.position.y - myRigidbody.position.y) < CS_Global.DISTANCE_GET_TOOL_Y) {
			autoMoveTarget.SendMessage ("PickUpTool");
			
			onAutoMove = false;
			screenMoveAxis = 0;
			ClearAutoMoveTarget ();
		}
	}

	private void SetAutoMoveTarget (GameObject g_gameObject) {
		autoMoveTarget = g_gameObject;

		//turn on AM_Select

		AM_Select.transform.position = g_gameObject.transform.position;
		AM_Select.SetActive (true);
	}

	private void ClearAutoMoveTarget () {
		autoMoveTarget = null;
		//turn off AM_Select
		AM_Select.SetActive (false);
	}

	private void UpdateMove () {
		//if the player is dead, do not move the player
		if (isDead == true || isGameOn == false) {
			//don't do player walk
			isWalking = false;
			myRigidbody.velocity = 
				new Vector3 (0, myRigidbody.velocity.y, 0);
			return;
		}

		//set the speed of the player
		float translation;

		if (screenMoveAxis != 0) {
			translation = screenMoveAxis * horizontalSpeed * speedRate;
		} else {
			translation = CS_GameInput.Horizontal (CS_Global.NAME_PLAYER) * horizontalSpeed * speedRate;
		}
		GetComponent<Rigidbody> ().velocity = 
			new Vector3 (translation, myRigidbody.velocity.y, 0);

		//change the directionof the player if he turns
		if (translation > 0)
			eulerRotation = CS_Global.EULER_ANGLES_BL;
		else if (translation < 0)
			eulerRotation = CS_Global.EULER_ANGLES_BR;
		
//		if (isGravityChanged) {
//			if(eulerRotation == CS_Global.EULER_ANGLES_BL)
//				eulerRotation = CS_Global.EULER_ANGLES_TL;
//			else if(eulerRotation == CS_Global.EULER_ANGLES_BR)
//				eulerRotation = CS_Global.EULER_ANGLES_TR;
//		}
		transform.rotation = Quaternion.Euler(eulerRotation);

		//if the player is walking, set the value of isWalking (for Animation)
		if (translation == 0)
			isWalking = false;
		else
			isWalking = true;
	}

	private void Jump () {
		if (isGrounded == true) {
			myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0);
			isGrounded = false;
		}
	}
	
	void OnCollisionStay (Collision coll) {
		//Debug.Log("OnCollisionStay " + "coll.gameObject.tag");
		if (coll.gameObject.tag == "Ground" && transform.position.y > coll.transform.position.y) {
			isGrounded = true;
			//Debug.Log("onGround");
		}
	} 

	public void MoveToGameObject (GameObject t_target) {
		//if the player is dead, do not move the player
		if (isDead == true || isGameOn == false) {
			return;
		}
		this.transform.position = 
			new Vector3 (t_target.transform.position.x, t_target.transform.position.y, CS_Global.POSITION_PLAYER_Z);
	}

	//==========Gravity==========
	public void ChangeGravity () {
		isGravityChanged = !isGravityChanged;
	}

	public void ResetGravity () {
		isGravityChanged = false;
	}

	private void UpdateGravity () {
		if (isGravityChanged) {
			//Debug.Log ("GravityChanged");
			myRigidbody.AddForce (Physics.gravity * -2);
		}
		//else 
		//	myRigidbody.AddForce (Vector3.down * CS_Global.GRAVITY * 1);
	}
	
	public void SetIsOnBike () {
		//for bike
		if (myTool == 2)
			SetSpeedRate (CS_Global.SPEED_RATE_BIKE);
		else
			SetSpeedRate (CS_Global.SPEED_RATE_WALK);
	}

	public void SetSpeedRate (float t_rate) {
		//for bike
		speedRate = t_rate;
	}

	public void UpdateAnimator () {
		//pass the value to AnimationController (update each frame)
		myAnimator.SetBool ("isWalking", isWalking);
		myAnimator.SetBool ("isDead", isDead);
		myAnimator.SetFloat ("velocityY", myRigidbody.velocity.y);
		myAnimator.SetInteger ("myTool", myTool);
	}

	public void AnimatorHammerHit () {
		myAnimator.SetTrigger ("hammerHit");
	}

	public void AnimatorGlovesPush (bool g_glovesPush) {
		myAnimator.SetBool ("glovesPush", g_glovesPush);
	}

	public void Kill () {
		//kill the player (just make it invisible)
		myPocketLeaveTool();
		//produce dead body
		DBMProduceDeadBody ();
		isDead = true;

		myRigidbody.velocity = Vector3.zero;
		ResetGravity ();
		//Reset Screen Move Axis
		screenMoveAxis = 0;
		onAutoMove = false;
		ClearAutoMoveTarget ();
	}

	public void GameOver () {
		//Called by Pocket
		//Reset Screen Move Axis
		screenMoveAxis = 0;
		onAutoMove = false;
		ClearAutoMoveTarget ();
	}

	public void Birth () {
		//recreate the player, set him to the womb
		this.gameObject.transform.position = myWomb.transform.position;
		isDead = false;
	}

	public void FindMyWomb () {
		myWomb = GameObject.Find (CS_Global.NAME_WOMB);
		if (myWomb == null)
			Debug.LogError ("Womb Not Found!");
	}

	void OnMouseDown () {
		//if click the player, drop the tool
		//myPocketLeaveTool();
	}

	public void FindMyPocket () {
		myPocket = GameObject.Find (CS_Global.NAME_PLAYERPOCKRT);
		if (myPocket == null)
			Debug.LogError ("PlayerPocket Not Found!");
	}

	private void myPocketLeaveTool () {
		//tell playerPocket to leave the tool
		myPocket.SendMessage ("LeaveTool");
	}

	public bool GetIsDead () {
		return isDead;
	}

	public void SetIsGameOn (bool t_isOn) {
		isGameOn = t_isOn;
	}

	private void DBMProduceDeadBody () {
		GameObject.Find (CS_Global.NAME_DEADBODYMANUFACTORY).SendMessage ("ProduceDeadBody", this.gameObject);
	}
}
