using UnityEngine;
using System.Collections;

public class CS_ParticleOnce : MonoBehaviour {
	public float deadTime = 1F;
	private float myTimer;
	// Use this for initialization
	void Start () {
		myTimer = 0.0F;
	}
	
	// Update is called once per frame
	void Update () {
		myTimer += Time.deltaTime;
		if (myTimer > deadTime)
			Destroy (this.gameObject);
	}
}