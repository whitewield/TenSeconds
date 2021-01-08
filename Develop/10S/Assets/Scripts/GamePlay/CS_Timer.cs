using UnityEngine;
using System.Collections;

public class CS_Timer : MonoBehaviour {

	private float timer;
	private bool isOn;
	private bool isPlayerAlive;
	public GameObject UI_Timer;
	public GameObject UI_DeathCount;

	public GameObject myPlayer;
	public GameObject myMessageBox;
	private int deathCount;

	// Use this for initialization
	void Start () {
		FindMyUITimer ();
		FindMyPlayer ();
		FindMyMessageBox ();
		UI_DeathCount = GameObject.Find ("UI_DeathCount");
		myMessageBox.SendMessage ("ResetDeathCountCurrent");
		SetIsOn(false);
		timer = CS_Global.TIME_DRUG;
		deathCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (isOn);
		if (isOn == true) {
			TimerRun ();
			CheckTimer ();
			UpdateUITimer ();
		}
		//Debug.Log (timer);
	}

	public void TimerStart()
	{
		SetIsOn(true);
		timer = CS_Global.TIME_START;
		isPlayerAlive = true;
	}

	private void TimerRun()
	{
		timer -= Time.deltaTime;
	}

	private void TimerPause()
	{
		SetIsOn(false);
	}

	private void FindMyPlayer()
	{
		myPlayer  = GameObject.FindGameObjectWithTag (CS_Global.NAME_PLAYER);
	}

	private void FindMyUITimer()
	{
		UI_Timer  = GameObject.Find (CS_Global.NAME_UI_TIMER);
	}

	private void FindMyMessageBox()
	{
		myMessageBox  = GameObject.Find (CS_Global.NAME_MESSAGEBOX);
	}

	private void CheckTimer()
	{

		if (timer < CS_Global.TIME_END && isPlayerAlive == true) {
			KillPlayer ();
		} else if (timer < CS_Global.TIME_RESTART && isPlayerAlive  == false) {
			RecreatePlayer();
			TimerStart();
			//Debug.Log ("restart");
		}
	}

	public void KillPlayer()
	{
		isPlayerAlive = false;
		myPlayer.SendMessage("Kill");
		deathCount++;
		UI_DeathCount.SendMessage ("ShowNumber", deathCount);
		myMessageBox.SendMessage ("AddDeathCount");
	}

	private void RecreatePlayer()
	{
		isPlayerAlive = true;
		myPlayer.SendMessage("Birth");
	}

	private void UpdateUITimer()
	{
		if(UI_Timer != null)
			UI_Timer.SendMessage ("ShowTime", timer);
	}

	private void SetIsOn(bool t_isOn)
	{
		isOn = t_isOn;
		myPlayer.SendMessage("SetIsGameOn", isOn);
	}

	public void GameOver()
	{
		isOn = false;
		myPlayer.SendMessage("SetIsGameOn", isOn);
	}

}
