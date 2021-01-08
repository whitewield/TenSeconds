using UnityEngine;
using System.Collections;

public class CS_Pass : MonoBehaviour {
	public GameObject myMessageBox;
	// Use this for initialization
	void Start () {
		myMessageBox = GameObject.Find (CS_Global.NAME_MESSAGEBOX) as GameObject;
		myMessageBox.SendMessage ("ShowPass");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
