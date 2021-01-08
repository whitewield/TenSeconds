using UnityEngine;
using System.Collections;

public class CS_MovePlayerOnClick : MonoBehaviour {

	void OnMouseDown () {
		GameObject.Find (CS_Global.NAME_PLAYER).GetComponent<CS_PlayerControl> ().SetAutoMove (this.gameObject);
	}
}
