using UnityEngine;
using System.Collections;

public class CS_DoorAnimationEvent : MonoBehaviour {

	public GameObject myElevatorManager;
	private Animator myAnimator;
	private bool open;

	void Start () {
		FindMyElevatorManager ();
		myAnimator = GetComponent<Animator>();
		open = false;
	}

	void Update () {
		myAnimator.SetBool("open", open);
	}
	
	public void Open()
	{
		if (myAnimator == null)
			myAnimator = GetComponent<Animator> ();
		open = true;
	}

	public void Close()
	{
		if (myAnimator == null)
			myAnimator = GetComponent<Animator> ();
		open = false;
	}

	public void SendMessageIsClosed()
	{
		myElevatorManager.SendMessage ("DoorIsClosed");
	}

	private void FindMyElevatorManager()
	{
		if(myElevatorManager == null)
			myElevatorManager = GameObject.Find(CS_Global.NAME_ELEVATORMANAGER);
		if(myElevatorManager == null)
			Debug.LogError("Where is my elevator manager?");
	}
}
