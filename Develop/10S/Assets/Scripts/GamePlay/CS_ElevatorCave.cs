using UnityEngine;
using System.Collections;

public class CS_ElevatorCave : MonoBehaviour {
	public GameObject myDoor_F1;
	public GameObject myDoor_F2;
	// Use this for initialization
	void Start () {
		if(myDoor_F1 == null || myDoor_F2 == null)
			Debug.LogError("I can not find my doors...");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OpenDoor(int t_doorNum)
	{
		if(t_doorNum == CS_Global.FLOOR_1)
			myDoor_F1.SendMessage("Open");
		else if(t_doorNum == CS_Global.FLOOR_2)
			myDoor_F2.SendMessage("Open");
	}
	public void CloseDoors()
	{
		myDoor_F1.SendMessage("Close");
		myDoor_F2.SendMessage("Close");
	}
}
