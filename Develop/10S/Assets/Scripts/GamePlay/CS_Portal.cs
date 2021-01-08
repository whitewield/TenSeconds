using UnityEngine;
using System.Collections;

public class CS_Portal : MonoBehaviour {
	public GameObject myParticle;
	private GameObject myPlayer;
	//private GameObject myPlayerPocket;
	//private bool isTouchable;
	private GameObject myPartnerPortal;
	
	void Start () {
		//make sure the tool is in the right position (z)
		this.transform.position = 
			new Vector3(transform.position.x, transform.position.y, CS_Global.POSITION_PORTAL_Z);
		//isTouchable = false;
		
		myPlayer = GameObject.Find("Player");
		//myPlayerPocket = GameObject.Find ("PlayerPocket");

		myParticle = Instantiate (myParticle, this.transform.position, Quaternion.identity) as GameObject;
		myParticle.transform.SetParent (this.transform);
	}
	
	void Update () {
		//SetStatus ();
		//ShowMyParticle ();
	}

	public void PickUpTool () {
		if (myPlayer.GetComponent<CS_PlayerControl>().GetIsDead() == true)
			return;
		if (myPartnerPortal != null)
			myPlayer.SendMessage ("MoveToGameObject", myPartnerPortal);
	}

	public void SetPartner(GameObject t_partner)
	{
		myPartnerPortal = t_partner;
	}

//	private float CountDistance()
//	{
//		return Vector3.Distance (this.transform.position, myPlayer.transform.position);
//	}
//	
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
	
	private void Destroy()
	{
		Destroy (this.gameObject);
	}
}
