using UnityEngine;
using System.Collections;

public class CS_Moon : MonoBehaviour {
	private GameObject myPlayer;
	// Use this for initialization
	void Start () {
		myPlayer = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 myTargetPosition = myPlayer.transform.position;
		myTargetPosition.z = transform.position.z;
		myTargetPosition.y = transform.position.y;

		transform.position = Vector3.Lerp (transform.position, myTargetPosition, Time.deltaTime);
	}
}
