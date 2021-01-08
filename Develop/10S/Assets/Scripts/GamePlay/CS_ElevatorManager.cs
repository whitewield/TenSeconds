using UnityEngine;
using System.Collections;

public class CS_ElevatorManager : MonoBehaviour {
	
	public GameObject myCave;
	public GameObject myBotton_F1;
	public GameObject myBotton_F2;
	public GameObject myBotton_Inside;
	private Animator myAnimator;
	public GameObject myDoor;
	private bool isDoorClosed;
	private int myTargetFloorNumber;
	private int myCurrentFloorNumber;

	void Start () {
		FindMyAnimator ();
		FindMyElevatorBottons ();
		FindMyElevatorCave ();
		Calling (CS_Global.FLOOR_2);
		myCurrentFloorNumber = 1;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateAnimator ();
		UpdateCloseDoors ();
	}

	public void Calling(int t_floorNum)
	{
		if (t_floorNum == CS_Global.ELEVATOR_INSIDE) {
			if (myCurrentFloorNumber == CS_Global.FLOOR_1)
				myTargetFloorNumber = CS_Global.FLOOR_2;
			else if (myCurrentFloorNumber == CS_Global.FLOOR_2)
				myTargetFloorNumber = CS_Global.FLOOR_1;
			Debug.Log ("calling" + myTargetFloorNumber);
		}
		else if (myTargetFloorNumber == myCurrentFloorNumber)
			myTargetFloorNumber = t_floorNum;

		//if (t_floorNum == myCurrentFloorNumber && isDoorClosed == false)
		//	Arrived ();
		//Debug.Log ("calling" + myTargetFloorNumber);
	}

	private void FindMyElevatorBottons()
	{
		if (myBotton_F1 == null)
			myBotton_F1 = GameObject.Find (CS_Global.NAME_ELEVATORBOTTON_F1);
		if (myBotton_F2 == null)
			myBotton_F2 = GameObject.Find (CS_Global.NAME_ELEVATORBOTTON_F2);
		if (myBotton_Inside == null)
			myBotton_Inside = GameObject.Find (CS_Global.NAME_ELEVATORBOTTON_INSIDE);
		if (myBotton_F1 == null || myBotton_F2 == null || myBotton_Inside == null)
			Debug.LogError ("Where is my elevator botton? I can not find them...");
	}

	private void FindMyElevatorCave()
	{
		if (myCave == null)
			myCave = GameObject.Find (CS_Global.NAME_ELEVATORCAVE);
		if (myCave == null)
			Debug.LogError ("Where is my elevator cave? I can not find it...");
	}

	private void FindMyAnimator()
	{
		myAnimator = GetComponent<Animator>();
		if (myDoor == null)
			Debug.LogError ("Where is my door? I can not find it...");
	}

	public void UpdateAnimator()
	{
		//pass the value to AnimationController (update each frame)
		if (isDoorClosed)
			myAnimator.SetInteger ("floorNumber", myTargetFloorNumber);
	}

	public void UpdateCloseDoors()
	{
		if (myTargetFloorNumber != myCurrentFloorNumber) 
		{
			myDoor.SendMessage("Close");
			myCave.SendMessage("CloseDoors", myTargetFloorNumber);
		}
	}

	public void Arrived()
	{
		isDoorClosed = false;
		myBotton_F1.SendMessage("Off");
		myBotton_F2.SendMessage("Off");
		myBotton_Inside.SendMessage("Off");
		myDoor.SendMessage ("Open");
		myCave.SendMessage ("OpenDoor", myTargetFloorNumber);
		myCurrentFloorNumber = myTargetFloorNumber;
	}

	public void DoorIsClosed()
	{
		isDoorClosed = true;
	}
}
