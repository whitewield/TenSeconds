using UnityEngine;
using System.Collections;

public class CS_ToolParticle : MonoBehaviour {
	private ParticleSystem myParticleSystem;

	void Start () {
		GetMyParticleSystem ();
	}


	void Update () {
	
	}

	private void GetMyParticleSystem()
	{
		myParticleSystem = GetComponent<ParticleSystem> ();
	}

	public void On()
	{
		if (myParticleSystem == null)
			GetMyParticleSystem ();
		if (myParticleSystem.isStopped)
			myParticleSystem.Play ();
	}

	public void Off()
	{
		if (myParticleSystem == null)
			GetMyParticleSystem ();
		if (myParticleSystem.isPlaying)
			myParticleSystem.Stop ();
	}

}
