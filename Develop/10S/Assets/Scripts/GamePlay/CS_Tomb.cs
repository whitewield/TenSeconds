using UnityEngine;
using System.Collections;

public class CS_Tomb : MonoBehaviour {
	public GameObject myParticle;
	public GameObject myFlower;
	public GameObject myGhost;
	private bool isUsed = false;
	//private bool isTouchable;

	void Start () {
		this.transform.position = 
			new Vector3(transform.position.x, transform.position.y, CS_Global.POSITION_DOOR_Z);
		//isTouchable = false;

		myParticle = Instantiate (myParticle, this.transform.position, Quaternion.identity) as GameObject;
		myParticle.transform.SetParent (this.transform);

		myFlower.SetActive (false);
	}

	public void PickUpTool () {
		if (isUsed == true)
			return;

		CS_PlayerControl t_myPlayerControl = GameObject.FindGameObjectWithTag (CS_Global.NAME_PLAYER).GetComponent<CS_PlayerControl> ();
		CS_PlayerPocket t_myPlayerPocket = GameObject.Find (CS_Global.NAME_PLAYERPOCKRT).GetComponent<CS_PlayerPocket> ();
		if (t_myPlayerControl.GetIsDead () == true)
			return;
		if (t_myPlayerPocket.GetMyTool () == CS_Global.TOOL_FLOWER) {
			t_myPlayerPocket.DestoryTool ();
			myFlower.SetActive (true);
			myParticle.SetActive (false);
			myGhost.SendMessage ("Disappear");
			isUsed = true;
			this.tag = CS_Global.TAG_UNTAGGED;
		}
	}

}
