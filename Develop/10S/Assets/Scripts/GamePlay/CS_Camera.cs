using UnityEngine;
using System.Collections;

public class CS_Camera : MonoBehaviour {
	public GameObject myTarget;
	private float cameraMoveSpeed = 5.0f;
	private float cameraPositionZ = -8;
	private Vector3 myTargetPosition;
	private float myPositionRatio;

	//private float maxDistance = 8;

	void Start () {
		FindMyPlayer ();
		myTargetPosition = transform.position;
	}

	void Update () {
		//FindMyPlayer ();
		SetMyTargetPosition();
		MoveCamera();
	}

	private void FindMyPlayer () {
		myTarget = GameObject.FindWithTag (CS_Global.TAG_PLAYER);
		myPositionRatio = 2;
	}

	public void FindMyMom () {
		myTarget = GameObject.Find (CS_Global.NAME_MOM);
		myPositionRatio = -1;
	}

	private void SetMyTargetPosition () {
		if (myTarget == null)
			return;
		
		myTargetPosition = myTarget.transform.position + myTarget.transform.right * myPositionRatio;
		myTargetPosition.z = cameraPositionZ;
		myTargetPosition.y -= cameraPositionZ / 8;
	}

	private void MoveCamera () {

		transform.position = Vector3.Lerp(transform.position, myTargetPosition, Time.deltaTime * cameraMoveSpeed);

		//float t_distance = Vector3.Distance (this.transform.position, myTargetPosition);
		//Debug.Log (t_distance);
//		if (t_distance > maxDistance)
//			transform.position = Vector3.Lerp(transform.position, myTargetPosition, Time.deltaTime * cameraMoveSpeed * (1 + t_distance - maxDistance));
//		else
//			transform.position = Vector3.Lerp(transform.position, myTargetPosition, Time.deltaTime * cameraMoveSpeed);

	}

	private void UpdateSpeed() {
	}

}
