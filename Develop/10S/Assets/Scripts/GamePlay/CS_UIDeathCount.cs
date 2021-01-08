using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CS_UIDeathCount : MonoBehaviour {

	public GameObject Shadow;

	void Start () {
		ShowNumber(0);
	}

	void Update () {
	
	}

	public void ShowNumber(int t_number)
	{
		this.GetComponent<TextMesh> ().text = t_number.ToString();
		if(Shadow != null)
			Shadow.GetComponent<TextMesh> ().text = t_number.ToString();
	}
}
