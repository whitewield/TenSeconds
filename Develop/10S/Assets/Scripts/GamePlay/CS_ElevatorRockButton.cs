using UnityEngine;
using System.Collections;

public class CS_ElevatorRockButton : CS_ElevatorRockBase {

	[SerializeField] CS_ElevatorRock myElevatorRock; 

	private Mode myMode;

	[SerializeField] int onNumber;
	[SerializeField] int offNumber;

	private SpriteRenderer mySpriteRenderer;
	[SerializeField] Sprite onSprite;
	[SerializeField] Sprite offSprite;

	private int lastCountObject;
	private int countObject = 0;

	void Start () {
		myMode = myElevatorRock.GetMyMode ();
		mySpriteRenderer = this.GetComponent<SpriteRenderer>();
		mySpriteRenderer.sprite = offSprite;
		lastCountObject = countObject;
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag != CS_Global.TAG_PLAYER && other.tag != CS_Global.TAG_TERRACOTTAARMY)
			return;

		countObject++;
		CheckStatus ();
	}

	void OnTriggerExit (Collider other) {
		if (other.tag != CS_Global.TAG_PLAYER && other.tag != CS_Global.TAG_TERRACOTTAARMY)
			return;

		countObject--;
		CheckStatus ();
	}

	private void CheckStatus () {
//		Debug.Log ("countObject = " + countObject);
		if (countObject == 0 && lastCountObject > 0) {
			if (myMode == Mode.MoveDirectly)
				myElevatorRock.MoveTo (offNumber);
			else
				myElevatorRock.AddToSwitchAmount (-1);

			mySpriteRenderer.sprite = offSprite;
		} else if (countObject > 0 && lastCountObject == 0) {
			if (myMode == Mode.MoveDirectly)
				myElevatorRock.MoveTo (onNumber);
			else
				myElevatorRock.AddToSwitchAmount (1);

			mySpriteRenderer.sprite = onSprite;
		} 

		if (countObject < 0)
			Debug.LogError ("countObject = " + countObject);

		lastCountObject = countObject;
	}
}
