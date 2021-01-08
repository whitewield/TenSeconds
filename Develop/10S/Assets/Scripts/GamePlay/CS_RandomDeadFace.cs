using UnityEngine;
using System.Collections;

public class CS_RandomDeadFace : MonoBehaviour {
	public Sprite[] deadFace;
	// Use this for initialization
	void Start () {
		int t_num = (int)(Random.value * deadFace.Length);
		this.GetComponent<SpriteRenderer> ().sprite = deadFace [t_num];
		//Debug.Log("dead face");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
