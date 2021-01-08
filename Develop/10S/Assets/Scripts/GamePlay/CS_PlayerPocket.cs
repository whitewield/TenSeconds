using UnityEngine;
using System.Collections;

public class CS_PlayerPocket : MonoBehaviour {
	private int myTool;
	private GameObject myPlayer;
	private GameObject myTimer;
	private bool isPlayerDead;
	public GameObject tool_Bottle;
	public GameObject tool_Bike;
	public GameObject tool_Ball;
	public GameObject tool_Shoes;
	public GameObject tool_PortalGun;
	public GameObject tool_Flower;
	public GameObject tool_Gloves;
	public GameObject tool_Hammer;

	public GameObject UI_Pocket;

	public GameObject PortalA;
	public GameObject PortalB;
	private GameObject Portal1;
	private GameObject Portal2;
	private int currentPortalNumber;

	public GameObject PT_Switch;
	public GameObject AM_BottleBreak;

	void Start () {
		
		FindUI ();

		myTool = CS_Global.TOOL_NULL;
		ShowTool ();
		
		FindMyPlayer ();
		FindMyTimer ();
	}

	void Update () {
		if (Input.GetButton ("PlayerUse"))
			UseTool ();
		if (Input.GetButton ("PlayerDrop"))
			LeaveTool ();
	}

	private void FindUI () {
		if(UI_Pocket == null)
			UI_Pocket = GameObject.Find("UI_Pocket");
	}

	public void PickUpTool (int g_tool) {
		//Do not pick up the tool if the player is dead
		isPlayerDead = myPlayer.GetComponent<CS_PlayerControl>().GetIsDead();
		if (isPlayerDead == true)
			return;

		//Show Particle
		Instantiate (PT_Switch, myPlayer.transform.position, myPlayer.transform.rotation);

		//if the player have a tool, leave the tool
		if (myTool != CS_Global.TOOL_NULL)
			LeaveTool ();

		myTool = g_tool;

		//set the player's speed rate (for bike), show the tool on character
		SetPlayerIsOnWhat ();
		
		//show the tool on UI
		ShowTool ();

		//if pick up bottle, win!
		if (myTool == CS_Global.TOOL_BOTTLE) {
			DestoryBottle ();
		}
	}

	public int SwitchTool (int g_tool) {
		//used by bird
		//Do not pick up the tool if the player is dead
		isPlayerDead = myPlayer.GetComponent<CS_PlayerControl>().GetIsDead();
		if (isPlayerDead == true)
			return g_tool;
		
		//Show Particle
		Instantiate (PT_Switch, myPlayer.transform.position, myPlayer.transform.rotation);

		//switch tool number
		int t_tool = myTool;
		myTool = g_tool;
		
		//set the player's speed rate (for bike), show the tool on character
		SetPlayerIsOnWhat ();
		
		//show the tool on UI
		ShowTool ();
		
		return t_tool;
	}

	public void LeaveTool () {
		//Show Particle
		Instantiate (PT_Switch, myPlayer.transform.position, myPlayer.transform.rotation);

		Vector3 t_position = 
			new Vector3 (myPlayer.transform.position.x, myPlayer.transform.position.y, CS_Global.POSITION_TOOL_Z);
		if (myTool == CS_Global.TOOL_BOTTLE)
			Instantiate (tool_Bottle, t_position, myPlayer.transform.rotation);
		else if (myTool == CS_Global.TOOL_BIKE) {
			Instantiate (tool_Bike, t_position, myPlayer.transform.rotation);
		} else if (myTool == CS_Global.TOOL_BALL)
			Instantiate (tool_Ball, t_position, myPlayer.transform.rotation);
		else if (myTool == CS_Global.TOOL_SHOES) {
			myPlayer.SendMessage ("ResetGravity");
			Instantiate (tool_Shoes, t_position, myPlayer.transform.rotation);
		} else if (myTool == CS_Global.TOOL_PORTAL)
			Instantiate (tool_PortalGun, t_position, myPlayer.transform.rotation);
		else if (myTool == CS_Global.TOOL_FLOWER)
			Instantiate (tool_Flower, t_position, myPlayer.transform.rotation);
		else if (myTool == CS_Global.TOOL_GLOVES)
			Instantiate (tool_Gloves, t_position, myPlayer.transform.rotation);
		else if (myTool == CS_Global.TOOL_HAMMER)
			Instantiate (tool_Hammer, t_position, myPlayer.transform.rotation);

		myTool = CS_Global.TOOL_NULL;
		//set the player's speed rate (for bike), show the tool on character
		SetPlayerIsOnWhat ();
		//show the tool on UI
		ShowTool ();
	}

	public void DestoryTool () {
		myTool = CS_Global.TOOL_NULL;
		SetPlayerIsOnWhat ();
		ShowTool ();
	}

	public void DestoryBottle () {
		if (myTool == CS_Global.TOOL_BOTTLE) {
			myTool = CS_Global.TOOL_NULL;
			SetPlayerIsOnWhat ();
			ShowTool ();
		}
		myTimer.SendMessage("GameOver");
		myPlayer.SendMessage("GameOver");
		GameObject t_AM_BottleBreak = 
			Instantiate (AM_BottleBreak, myPlayer.transform.position, Quaternion.identity) as GameObject;
		t_AM_BottleBreak.transform.SetParent (myPlayer.transform);
	}

	public void ShowTool () {
		//show the tool on UI
		UI_Pocket.GetComponent<CS_UIPocket> ().ShowTool (myTool);
	}

	public void SetPlayerIsOnWhat () {
		myPlayer.GetComponent<CS_PlayerControl> ().myTool = GetMyTool ();
		myPlayer.GetComponent<CS_PlayerControl> ().SetIsOnBike ();
	}

	private void FindMyPlayer () {
		myPlayer = GameObject.FindWithTag (CS_Global.NAME_PLAYER);
	}

	private void FindMyTimer () {
		myTimer = GameObject.Find (CS_Global.NAME_TIMER);
	}

	public bool GetIsPlayerDead () {
		return isPlayerDead;
	}

	public void UseTool () {
		if (myTool == CS_Global.TOOL_BOTTLE) {
			//GameObject.Find (CS_Global.NAME_TRANSITIONMANAGER).SendMessage ("StartAnimationOut", "Pass");
			//DestoryBottle ();

		}else if (myTool == CS_Global.TOOL_SHOES) {
			myPlayer.SendMessage("ChangeGravity");
		}else if (myTool == CS_Global.TOOL_PORTAL) {
			ShootPortal();
		}
		else
			return;
	}

	private void ShootPortal () {
		if (Portal1 == null) {
			Portal1 = Instantiate (PortalA, myPlayer.transform.position + Vector3.up * CS_Global.POSITION_PORTAL_DY, Quaternion.identity) as GameObject;
			currentPortalNumber = 1;
		} else if (Portal2 == null) {
			Portal2 = Instantiate (PortalB, myPlayer.transform.position + Vector3.up * CS_Global.POSITION_PORTAL_DY, Quaternion.identity) as GameObject;
			currentPortalNumber = 2;
			Portal1.GetComponent<CS_Portal>().SetPartner(Portal2);
			Portal2.GetComponent<CS_Portal>().SetPartner(Portal1);
		} else if (currentPortalNumber == 1) {
			Portal2.transform.position = 
				new Vector3(myPlayer.transform.position.x, myPlayer.transform.position.y + CS_Global.POSITION_PORTAL_DY, CS_Global.POSITION_PORTAL_Z);
			currentPortalNumber = 2;
		} else if (currentPortalNumber == 2) {
			Portal1.transform.position = 
				new Vector3(myPlayer.transform.position.x, myPlayer.transform.position.y + CS_Global.POSITION_PORTAL_DY, CS_Global.POSITION_PORTAL_Z);
			currentPortalNumber = 1;
		}
	}

	public int GetMyTool () {
		return myTool;
	}
	
}
