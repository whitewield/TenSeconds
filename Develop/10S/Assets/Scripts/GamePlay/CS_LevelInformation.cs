using UnityEngine;
using System.Collections;

public class CS_LevelInformation : MonoBehaviour {
	private GameObject myMessageBox;
	public int myStage;
	public int myLevel;

	void Start () {
		myMessageBox = GameObject.Find (CS_Global.NAME_MESSAGEBOX) as GameObject;
		myMessageBox.SendMessage ("SetStage", myStage);
		myMessageBox.SendMessage ("SetLevel", myLevel);
	}

	void Update () {
	
	}

	public void Again ()
	{
		GameObject.Find (CS_Global.NAME_TRANSITIONMANAGER).SendMessage ("StartAnimationOut", ("S" + myStage.ToString() + "_L" + myLevel.ToString()));
	}

	public void Back ()
	{
		GameObject.Find (CS_Global.NAME_TRANSITIONMANAGER).SendMessage ("StartAnimationOut", ("Stage" + myStage.ToString()));
	}
}
