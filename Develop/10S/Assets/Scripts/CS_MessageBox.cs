using UnityEngine;
using System.Collections;

public class CS_MessageBox : MonoBehaviour {
	public string stage;
	public string level;
	public int deathCountTotal;
	public int deathCountCurrent;

	public string currentBGM;

	public int stageManagerNumber = 1;

	void Start () {
		CS_GameSave.CreatGameSave ();
		if (CS_GameSave.LoadGame("stage1", "level1") == "0")
			CS_GameSave.SaveGame("stage1", "level1", "1");
		stage = "0";
		level = "0";
	}

	void Awake () {
		DontDestroyOnLoad(transform.gameObject);
	}

	public void SetStage (string t_stage) {
		stage = t_stage;
	}

	public void SetLevel (string t_level) {
		level = t_level;
	}

	public void AddDeathCount () {
		deathCountTotal++;
		deathCountCurrent++;
	}

	public void ResetDeathCountTotal () {
		deathCountTotal = 0;
	}
	
	public void ResetDeathCountCurrent () {
		//call by CS_Timer
		deathCountCurrent = 0;
	}

	public void Destroy () {
		Destroy (this.gameObject);
	}

	public void Save (string t_status) {
		CS_GameSave.SaveGame("stage" + stage, "level" + level, t_status);
	}

	public void OpenNextLevel () {
		if(LoadNext() == "0")
			CS_GameSave.SaveGame ("stage" + stage, "level" + (int.Parse(level) + 1).ToString (), "1");
	}

	public void OpenNextStage () {
		if(LoadNextStage() == "0")
			CS_GameSave.SaveGame ("stage" + (int.Parse(stage) + 1).ToString (), "level1", "1");
	}

	public string LoadCurrent () {
		return CS_GameSave.LoadGame ("stage" + stage, "level" + level);
	}

	public string LoadNext () {
		return CS_GameSave.LoadGame ("stage" + stage, "level" + (int.Parse(level) + 1).ToString ());
	}

	public string LoadNextStage () {
		return CS_GameSave.LoadGame ("stage" + (int.Parse(stage) + 1).ToString (), "level1");
	}

	public void BtnNext () {
		SetLevel ((int.Parse (level) + 1).ToString ());
		GameObject.Find (CS_Global.NAME_TRANSITIONMANAGER).SendMessage ("StartAnimationOut", ("S" + stage + "_L" + level));
	}

	public void BtnMenu () {
		GameObject.Find (CS_Global.NAME_TRANSITIONMANAGER).SendMessage ("StartAnimationOut", ("Stage" + stage));

		Time.timeScale = 1;
	}
	
	public void BtnAgain () {
		GameObject.Find (CS_Global.NAME_TRANSITIONMANAGER).SendMessage ("StartAnimationOut", ("S" + stage + "_L" + level));
	}

	public int CheckPerfectDeathCount () {
		int[] t_perfectArray;
		switch (stage) {
		case "1" : t_perfectArray = CS_Global.PERFECT_STAGE1; break;
		case "2" : t_perfectArray = CS_Global.PERFECT_STAGE2; break;
		case "3" : t_perfectArray = CS_Global.PERFECT_STAGE3; break;
		case "4" : t_perfectArray = CS_Global.PERFECT_STAGE4; break;
		default : t_perfectArray = CS_Global.PERFECT_STAGE1; break;
		}
		//Debug.Log ("perfect:" + t_perfectArray [level - 1]);
		return t_perfectArray [int.Parse(level) - 1];
	}

	public void ShowPass () {
		int perfectDeathCount = CheckPerfectDeathCount ();
		if (perfectDeathCount < deathCountCurrent) {
			GameObject.Find (CS_Global.NAME_PASS_PERFECT).SetActive (false);
			GameObject.Find (CS_Global.NAME_PASS_PERFECTHEART).SetActive (false);
			if (int.Parse (LoadCurrent ()) < int.Parse (CS_Global.BOTTLE_DONE))
				Save (CS_Global.BOTTLE_DONE);
		} else {
			GameObject.Find (CS_Global.NAME_PASS_CLEAR).SetActive (false);
			Save (CS_Global.BOTTLE_PERFECT);
		}
		OpenNextLevel ();
		GameObject.Find (CS_Global.NAME_DEATHCOUNT_PERFECT).SendMessage ("ShowNumber", perfectDeathCount);
		GameObject.Find (CS_Global.NAME_DEATHCOUNT_YOURS).SendMessage ("ShowNumber", deathCountCurrent);

	}

	public void BGMPlay (string g_BGM) {
		currentBGM = g_BGM;
		if (currentBGM == "")
			return;

		AudioSource t_BGM = GameObject.Find(currentBGM).GetComponent<AudioSource>();
		if (t_BGM != null)
			t_BGM.Play ();
	}

	public void BGMStop () {
		if (currentBGM == "")
			return;

		AudioSource t_BGM = GameObject.Find(currentBGM).GetComponent<AudioSource>();
		if (t_BGM != null)
			t_BGM.Stop ();
	}

	public void GetStageManagerNumber (GameObject g_stageManager) {
		Debug.Log ("GetStageManagerNumber:" + g_stageManager);
		g_stageManager.SendMessage ("SetStageNumber", stageManagerNumber);
	}

	public void SetStageManagerNumber (int g_stageNumber) {
		stageManagerNumber = g_stageNumber;
	}

}
