using UnityEngine;
using System.Collections;

public class CS_StageManager : MonoBehaviour {

	private Animator myAnimator;
	public GameObject myGear;
	private Animator myGearAnimator;
	public int stageNumber;

	public GameObject myBtnL;
	public GameObject myBtnR;

	void Start () {
		myAnimator = GetComponent<Animator> ();
		myGearAnimator = myGear.GetComponent<Animator> ();
		stageNumber = 1;

		GameObject.Find (CS_Global.NAME_MESSAGEBOX).SendMessage ("GetStageManagerNumber", this.gameObject);

		UpdateNumber ();
		UpdateAnimator ();
		UpdateBtn ();
	}

	public void SetStageNumber (int g_stageNumber) {
		Debug.Log ("SetStageNumber:" + g_stageNumber);
		stageNumber = g_stageNumber;

		UpdateNumber ();
		UpdateAnimator ();
		UpdateBtn ();
	}

	public void UpdateAnimator () {
		//pass the value to AnimationController (update each frame)
		myAnimator.SetInteger("stageNum", stageNumber);
		myGearAnimator.SetInteger("stageNum", stageNumber);
	}

	public void BtnLeft () {
		stageNumber--;

		UpdateNumber ();
		UpdateAnimator ();
		UpdateBtn ();
	}

	public void BtnRight () {
		stageNumber++;

		UpdateNumber ();
		UpdateAnimator ();
		UpdateBtn ();
	}

	public void UpdateNumber () {
		if (stageNumber > CS_Global.AMOUNT_STAGES)
			stageNumber = 1;
		if (stageNumber < 1)
			stageNumber = CS_Global.AMOUNT_STAGES;

		GameObject.Find (CS_Global.NAME_MESSAGEBOX).SendMessage ("SetStageManagerNumber", stageNumber);
	}

	public void UpdateBtn () {
		if (stageNumber == CS_Global.AMOUNT_STAGES) {
			if (myBtnR.activeSelf == true) {
				myBtnR.SetActive (false);
			}
		} else if (stageNumber == 1) {
			if (myBtnL.activeSelf == true) {
				myBtnL.SetActive (false);
			}
		} else {
			if (myBtnL.activeSelf == false) {
				myBtnL.SetActive (true);
			}
			if (myBtnR.activeSelf == false) {
				myBtnR.SetActive (true);
			}
		}
	}
}
