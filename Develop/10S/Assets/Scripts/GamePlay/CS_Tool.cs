using UnityEngine;
using System.Collections;

public class CS_Tool : MonoBehaviour {
	public int myToolNumber;
	public GameObject myParticle;
	//private bool isTouchable;

	void Start () {
		//make sure the tool is in the right position (z)
		this.transform.position = 
			new Vector3(transform.position.x, transform.position.y, CS_Global.POSITION_TOOL_Z);
		//isTouchable = false;


		myParticle = Instantiate (myParticle, this.transform.position, Quaternion.identity) as GameObject;
		myParticle.transform.SetParent (this.transform);
	}
	
	void Update () {
		//SetStatus ();
		//ShowMyParticle ();
	}

	public void PickUpTool () {
		if (GameObject.FindGameObjectWithTag (CS_Global.NAME_PLAYER).GetComponent<CS_PlayerControl> ().GetIsDead () == true)
			return;
		GameObject.Find (CS_Global.NAME_PLAYERPOCKRT).SendMessage("PickUpTool",myToolNumber);
		Destroy();
	}

//	private float CountDistance () {
//		return Mathf.Abs (this.transform.position.x - myPlayer.transform.position.x);
//	}

//	private void SetStatus () {
//		if (myPlayer == null) {
//			isTouchable = false;
//			return;
//		}
//		if (CountDistance () < CS_Global.DISTANCE_WARNING)
//			isTouchable = true;
//		else
//			isTouchable = false;
//	}
//
//	private bool GetStatus () {
//		return isTouchable;
//	}

//	private void ShowMyParticle () {
//		if (GetStatus () == true) {
//			myParticle.SendMessage("On");
//		}
//		else myParticle.SendMessage("Off");
//	}

	private void Destroy () {
		Destroy (this.gameObject);
	}
}
