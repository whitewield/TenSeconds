using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CS_TransitionManager : MonoBehaviour {
	
	public GameObject transition;
	private Animator myAnimator;
	private string nextScene;
	
	void Start () {
		this.name = CS_Global.NAME_TRANSITIONMANAGER;
		myAnimator = transition.GetComponent<Animator> ();
	}

	public void StartAnimationOut(string t_nextScene)
	{
		if(t_nextScene == null)
			Debug.LogError("next scene not set!");
		nextScene = t_nextScene;

		myAnimator.SetTrigger ("nextScene");
	}
	
	public IEnumerator GoToNextScene () {
		//Stop BGM
		//GameObject.Find (CS_Global.NAME_MESSAGEBOX).SendMessage ("BGMStop");

		AsyncOperation async = SceneManager.LoadSceneAsync (nextScene);
		yield return async;
		Debug.Log("Loading complete");
	}
	
}
