using UnityEngine;
using System.Collections;

public class CS_DeadBodyManufactory : MonoBehaviour {

	public GameObject PF_DeadBody;

	void Start () {
		this.name = CS_Global.NAME_DEADBODYMANUFACTORY;
	}

	void Update () {
	
	}
	
	public void ProduceDeadBody(GameObject t_player)
	{
		Vector3 t_position = 
			new Vector3 (t_player.transform.position.x, t_player.transform.position.y, CS_Global.POSITION_DEADBODY_Z);
		GameObject t_deadBody = 
			Instantiate (PF_DeadBody, t_position, t_player.transform.rotation) as GameObject;
		float t_randomZ = (Random.value - 0.5f) * CS_Global.ROTATION_DEADBODY;
		t_deadBody.transform.Rotate(0, 0, t_randomZ);
	}
}
