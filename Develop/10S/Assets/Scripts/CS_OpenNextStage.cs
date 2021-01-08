using UnityEngine;
using System.Collections;

public class CS_OpenNextStage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find (CS_Global.NAME_MESSAGEBOX).SendMessage ("OpenNextStage");
	}
}
