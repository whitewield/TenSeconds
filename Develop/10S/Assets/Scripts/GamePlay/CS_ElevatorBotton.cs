using UnityEngine;
using System.Collections;

public class CS_ElevatorBotton : MonoBehaviour {
	
	public GameObject myParticle;
	public Sprite SP_On;
	public Sprite SP_Off;
	public GameObject myElevatorManager;
	private SpriteRenderer mySpriteRenderer;
	public int myFloorNumber;
	private bool isOn;
	private bool isTouchable;

	void Start () {
		mySpriteRenderer = this.GetComponent<SpriteRenderer> ();

		myElevatorManager = GameObject.Find(CS_Global.NAME_ELEVATORMANAGER);

		myParticle = Instantiate (myParticle, this.transform.position, Quaternion.identity) as GameObject;
		myParticle.transform.SetParent (this.transform);

		if(SP_On == null || SP_Off == null)
			Debug.LogError("Elevator botton sprite not found!");
		if (myFloorNumber != CS_Global.FLOOR_1 && myFloorNumber != CS_Global.FLOOR_2) {
			Debug.Log ("I am in the elevator?!");
			myFloorNumber = CS_Global.ELEVATOR_INSIDE;
		}

		isOn = false;

		ShowSprite ();
	}
	
	void Update () {
		//SetIsTouchable ();
		//Debug.Log(GetIsTouchable());
		//ShowMyParticle ();
	}

	public void PickUpTool () {
		if (GameObject.FindGameObjectWithTag (CS_Global.NAME_PLAYER).GetComponent<CS_PlayerControl> ().GetIsDead () == true)
			return;

		if (isOn == true)
			return;

		myElevatorManager.SendMessage("Calling",myFloorNumber);
		isOn = true;
		ShowSprite();
	}

//	private float CountDistance () {
//		return Vector3.Distance (this.transform.position, myPlayer.transform.position);
//	}
//
//	private void SetIsTouchable()
//	{
//		if (myPlayer == null) 
//		{
//			isTouchable = false;
//			return;
//		}
//		if (CountDistance () < CS_Global.DISTANCE_PRESS_BUTTON)
//			isTouchable = true;
//		else
//			isTouchable = false;
//	}
//
//	private bool GetIsTouchable()
//	{
//		return isTouchable;
//	}

	private void ShowSprite()
	{
		if (isOn)
			mySpriteRenderer.sprite = SP_On;
		else 
			mySpriteRenderer.sprite = SP_Off;
	}

//	private void ShowMyParticle()
//	{
//		if (GetIsTouchable () == true) {
//			myParticle.SendMessage("On");
//		}
//		else myParticle.SendMessage("Off");
//	}

//	private void FindMyElevatorManager()
//	{
//		if(myElevatorManager == null)
//			myElevatorManager = GameObject.Find(CS_Global.NAME_ELEVATORMANAGER);
//		if(myElevatorManager == null)
//			Debug.LogError("Where is my elevator manager?");
//	}
//
//	private void FindMyPlayer()
//	{
//		if (myPlayer == null)
//			myPlayer = GameObject.Find ("Player");
//		if (myPlayer == null)
//			Debug.LogError("Where is my player?");
//	}

	public void Off()
	{
		isOn = false;
		ShowSprite ();
	}
}
