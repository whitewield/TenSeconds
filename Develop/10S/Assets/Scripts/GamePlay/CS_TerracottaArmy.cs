using UnityEngine;
using System.Collections;

public class CS_TerracottaArmy : MonoBehaviour {
	[SerializeField] GameObject deadBody;
	public GameObject myParticle;
	private bool isSmashed = false;
	private CS_PlayerControl myPlayerControl;

	void Start () {
		myPlayerControl = GameObject.FindGameObjectWithTag (CS_Global.NAME_PLAYER).GetComponent<CS_PlayerControl> ();
	}

	void OnCollisionEnter (Collision collision) {
		if (collision.transform.tag == CS_Global.TAG_PLAYER) {
			if (collision.transform.GetComponent<CS_PlayerControl> ().myTool == CS_Global.TOOL_GLOVES)
				myPlayerControl.AnimatorGlovesPush (true);
			else
				myPlayerControl.AnimatorGlovesPush (false);
		}
	}

	void OnCollisionExit (Collision collision) {
		if (collision.transform.tag == CS_Global.TAG_PLAYER)
			myPlayerControl.AnimatorGlovesPush (false);
	}

	void OnCollisionStay (Collision collision) {
		if (isSmashed == true)
			return;
		
		if (collision.transform.tag == CS_Global.TAG_PLAYER) {
			if (collision.transform.GetComponent<CS_PlayerControl> ().myTool == CS_Global.TOOL_GLOVES) {
				this.GetComponent<Rigidbody> ().mass = 1;
				myPlayerControl.AnimatorGlovesPush (true);
			} else if (collision.transform.GetComponent<CS_PlayerControl> ().myTool == CS_Global.TOOL_HAMMER) {
				myPlayerControl.AnimatorGlovesPush (false);
				Smashing ();
			} else {
				this.GetComponent<Rigidbody> ().mass = 1E+09f;
				myPlayerControl.AnimatorGlovesPush (false);
			}
		} else
			return;
	}

	private void Smashing () {
		isSmashed = true;

		myPlayerControl.AnimatorHammerHit ();
		StartCoroutine(CS_Global.DelayToInvokeDo(() =>
			{
				CapsuleCollider[] t_colliderArray = GetComponents <CapsuleCollider> ();
				foreach (CapsuleCollider t_collider in t_colliderArray)
					t_collider.center += Vector3.forward * 2;
			}, 0.4f));
		StartCoroutine(CS_Global.DelayToInvokeDo(() =>
			{
				Smashed ();
			}, 0.5f));
	}

	private void Smashed () {
		//GameObject.FindGameObjectWithTag (CS_Global.NAME_PLAYER).GetComponent<CS_PlayerControl> ().AnimatorHammerHit ();
		Vector3 t_position = new Vector3 (transform.position.x, transform.position.y, CS_Global.POSITION_DEADBODY_Z);
		Instantiate (deadBody, t_position, transform.rotation);
		Instantiate (myParticle, transform.position, transform.rotation);
		Destroy (this.gameObject);
	}
}
