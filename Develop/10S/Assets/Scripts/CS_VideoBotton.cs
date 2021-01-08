using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CS_VideoBotton : MonoBehaviour {
	public string myStage;
	public string myLevel;
	public GameObject myManager;
	public string myMessageMethodName;
	//private SpriteRenderer mySpriteRenderer;
	
	private string status;

	public AudioClip mySFX;
	
	void Start () {
		//mySpriteRenderer = this.GetComponent<SpriteRenderer> ();
		status = CS_GameSave.LoadGame ("stage" + myStage, "level" + myLevel);
		
		if (status == "0") {
			this.gameObject.SetActive(false);
		}
		//Debug.Log ("stage" + myStage.ToString() + "-" + "level" + myLevel.ToString() + " " + myStage + ":" + myLevel + ":" + status);
	}

	
	void OnMouseDown () {
		//BUG : CANNOT ENTER LEVEL
		if (status == CS_Global.BOTTLE_LOCKED)
			return;

		myManager.SendMessage (myMessageMethodName, "S" + myStage + "_L" + myLevel);
		GameObject myMessageBox = GameObject.Find (CS_Global.NAME_MESSAGEBOX) as GameObject;
		myMessageBox.SendMessage ("SetStage", myStage);
		myMessageBox.SendMessage ("SetLevel", myLevel);
		Debug.Log("send");

		if (mySFX != null)
			CS_AudioManager.Instance.PlaySFX (mySFX);
	}
}