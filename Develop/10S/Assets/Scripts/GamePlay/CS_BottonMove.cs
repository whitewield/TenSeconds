using UnityEngine;
using System.Collections;

public class CS_BottonMove : MonoBehaviour {
	private GameObject myManager;
	public string myMessageMethodName;
	public int downValue;
	public int upValue;

	void Start () {
		myManager = GameObject.Find (CS_Global.NAME_PLAYER);
	}

	void Update () {
		
	}
	
	void OnMouseDown(){
		myManager.SendMessage (myMessageMethodName, downValue);
	}

	void OnMouseUp()
	{
		myManager.SendMessage (myMessageMethodName, upValue);
	}
}
