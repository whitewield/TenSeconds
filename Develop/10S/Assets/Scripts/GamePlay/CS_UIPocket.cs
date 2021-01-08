using UnityEngine;
using System.Collections;

public class CS_UIPocket : MonoBehaviour {

	public GameObject btnDrop;

	public GameObject UI_Hand;
	public GameObject UI_Bottle;
	public GameObject UI_Bike;
	public GameObject UI_Ball;
	public GameObject UI_Shoes;
	public GameObject UI_PortalGun;
	public GameObject UI_Flower;
	public GameObject UI_Gloves;
	public GameObject UI_Hammer;


	void OnMouseDown(){
		GameObject.Find (CS_Global.NAME_PLAYERPOCKRT).SendMessage ("UseTool");
	}

	public void ShowTool(int g_myTool)
	{
		//show the tool on UI

		if (UI_Hand.activeSelf == true)
			UI_Hand.SetActive (false);
		if (UI_Bottle.activeSelf == true)
			UI_Bottle.SetActive (false);
		if (UI_Bike.activeSelf == true)
			UI_Bike.SetActive (false);
		if (UI_Ball.activeSelf == true)
			UI_Ball.SetActive (false);
		if (UI_Shoes.activeSelf == true)
			UI_Shoes.SetActive (false);
		if (UI_PortalGun.activeSelf == true)
			UI_PortalGun.SetActive (false);
		if (UI_Flower.activeSelf == true)
			UI_Flower.SetActive (false);
		if (UI_Gloves.activeSelf == true)
			UI_Gloves.SetActive (false);
		if (UI_Hammer.activeSelf == true)
			UI_Hammer.SetActive (false);

		if (g_myTool == CS_Global.TOOL_NULL)
			UI_Hand.SetActive (true);
		else if (g_myTool == CS_Global.TOOL_BOTTLE)
			UI_Bottle.SetActive (true);
		else if (g_myTool == CS_Global.TOOL_BIKE)
			UI_Bike.SetActive (true);
		else if (g_myTool == CS_Global.TOOL_BALL)
			UI_Ball.SetActive (true);
		else if (g_myTool == CS_Global.TOOL_SHOES)
			UI_Shoes.SetActive (true);
		else if (g_myTool == CS_Global.TOOL_PORTAL)
			UI_PortalGun.SetActive (true);
		else if (g_myTool == CS_Global.TOOL_FLOWER)
			UI_Flower.SetActive (true);
		else if (g_myTool == CS_Global.TOOL_GLOVES)
			UI_Gloves.SetActive (true);
		else if (g_myTool == CS_Global.TOOL_HAMMER)
			UI_Hammer.SetActive (true);

		//show drop button

		if (g_myTool == CS_Global.TOOL_NULL)
			btnDrop.SetActive (false);
		else
			btnDrop.SetActive (true);


	}
}
