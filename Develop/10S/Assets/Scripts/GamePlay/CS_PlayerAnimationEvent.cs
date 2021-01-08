using UnityEngine;
using System.Collections;

public class CS_PlayerAnimationEvent : MonoBehaviour {


	void Start () {
	
	}

	void Update () {
	
	}

	public void SendMessage_Timer_Start()
	{
		GameObject t_Timer = GameObject.Find (CS_Global.NAME_TIMER);
		if (t_Timer != null)
			t_Timer.SendMessage ("TimerStart");
		else
			Debug.LogError ("Timer Not Found!");
	}
}
