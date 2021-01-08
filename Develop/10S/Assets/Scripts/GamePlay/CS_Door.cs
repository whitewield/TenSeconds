using UnityEngine;
using System.Collections;

public class CS_Door : MonoBehaviour {
	public GameObject myParticle;
	public GameObject myPartnerDoor;
	//private bool isTouchable;

	void Start () {
		this.transform.position = 
			new Vector3(transform.position.x, transform.position.y, CS_Global.POSITION_DOOR_Z);
		//isTouchable = false;

		myParticle = Instantiate (myParticle, this.transform.position, Quaternion.identity) as GameObject;
		myParticle.transform.SetParent (this.transform);
	}
	
	// Update is called once per frame
	void Update () {
		//SetStatus ();
		//ShowMyParticle ();
	}

	public void PickUpTool () {
		GameObject t_myPlayer = GameObject.FindGameObjectWithTag (CS_Global.NAME_PLAYER) as GameObject;
		if (t_myPlayer.GetComponent<CS_PlayerControl> ().GetIsDead () == true)
			return;
		if (myPartnerDoor != null)
			t_myPlayer.SendMessage("MoveToGameObject", myPartnerDoor);
	}

//	private void FindMyPlayer()
//	{
//		myPlayer = GameObject.Find(CS_Global.NAME_PLAYER);
//	}

//	private void SetStatus()
//	{
//		if (myPlayer == null) 
//		{
//			isTouchable = false;
//			return;
//		}
//		if (CountDistance () < CS_Global.DISTANCE_USE_PORTAL)
//			isTouchable = true;
//		else
//			isTouchable = false;
//	}
//	
//	private bool GetStatus()
//	{
//		return isTouchable;
//	}
//	
//	private void ShowMyParticle()
//	{
//		if (GetStatus () == true) {
//			myParticle.SendMessage("On");
//		}
//		else myParticle.SendMessage("Off");
//	}
//
//	private float CountDistance()
//	{
//		return Vector3.Distance (this.transform.position, myPlayer.transform.position);
//	}
}
