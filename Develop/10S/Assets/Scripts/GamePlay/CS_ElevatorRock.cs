using UnityEngine;
using System.Collections;

public class CS_ElevatorRock : CS_ElevatorRockBase {

	[SerializeField] Mode myMode;

	[SerializeField] float[] posYs;
	public int switchAmount;

	private Vector3 targetPosition;
	private bool onMove;

	private float myMoveSpeed = 2f;

	void Start () {
		targetPosition = transform.position;
		onMove = false;
	}
		
	void Update () {
		if (!onMove)
			return;
		
		if (Vector3.Distance (transform.position, targetPosition) < CS_Global.DISTANCE_MOVE) {
			transform.position = targetPosition;
			onMove = false;
		}
		transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime * myMoveSpeed);
	}

	public void MoveTo (int g_num) {
		onMove = true;
		if (g_num > posYs.Length - 1)
			targetPosition = new Vector3 (transform.position.x, posYs[posYs.Length - 1], transform.position.z);
		else if (g_num < 0)
			targetPosition = new Vector3 (transform.position.x, posYs[0], transform.position.z);
		else
			targetPosition = new Vector3 (transform.position.x, posYs [g_num], transform.position.z);
	}

	public void AddToSwitchAmount (int g_addNum) {
		if (myMode == Mode.MoveDirectly)
			return;
		
		switchAmount += g_addNum;
		MoveTo(switchAmount);
	}

	public Mode GetMyMode () {
		return myMode;
	}
}
