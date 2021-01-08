using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CS_UITimer : MonoBehaviour {

	public GameObject myMask;
	private Vector3 empty = new Vector3(0.0f, 0, 1);
	private Vector3 full = new Vector3(4.5f, 0, 1);

	void Start () {
		if(myMask == null)
			Debug.LogError("Can not find my mask!");
	}
	
	void Update () {

	}

	public void ShowTime(float t_time)
	{
		if (t_time > CS_Global.TIME_START)
			myMask.transform.localPosition = full;
		else if (t_time < CS_Global.TIME_END)
			myMask.transform.localPosition = empty;
		else 
			myMask.transform.localPosition = 
				t_time / (CS_Global.TIME_START - CS_Global.TIME_END) * (full - empty) + empty;
	}
}
