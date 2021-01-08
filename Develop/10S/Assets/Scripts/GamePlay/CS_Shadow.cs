using UnityEngine;
using System.Collections;

public class CS_Shadow : MonoBehaviour {
	[SerializeField] GameObject myShadow;
	[SerializeField] float mySizeRatio = 1.0f;
	private RaycastHit myHit;
	private Ray myRay;
	private Quaternion myRotation;
	private Vector3 deltaPosition;
	private float maxDistance = 20;
	private int layerMask = 1 << 18;

	void Start () {
		myShadow = Instantiate (myShadow) as GameObject;
		myRotation = myShadow.transform.rotation;
		myShadow.transform.localScale = myShadow.transform.localScale * mySizeRatio;
		myShadow.transform.SetParent (this.transform);
		deltaPosition = CS_Global.DISTANCE_SHADOW * Vector3.up;
		UpdatePosition ();
	}

	void Update () {
		UpdatePosition ();
	}

	private void UpdatePosition () {
		myRay = new Ray (transform.position, Vector3.down);
		if (Physics.Raycast (myRay, out myHit, maxDistance, layerMask)) {
			//if (myHit.rigidbody != null)
			myShadow.transform.position = myHit.point + deltaPosition;
		}
		myShadow.transform.rotation = myRotation;
	}


}
