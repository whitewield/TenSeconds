using UnityEngine;
using System.Collections;

public static class CS_GameInput
{
	public static bool Fire(string t_controller)
	{
		if (Application.platform == RuntimePlatform.WindowsPlayer) {
			//PC -> == 0, Mac -> <= 0
			if (Input.GetAxis (t_controller + "FireTrigger") == 0) {
				if (Input.GetButtonDown (t_controller + "FireButton")) {
					return true;
				} else
					return false;
			} else
				return true;
		} else if (Application.platform == RuntimePlatform.OSXPlayer) {
			if (Input.GetAxis (t_controller + "FireTrigger") <= 0) {
				if (Input.GetButtonDown (t_controller + "FireButton")) {
					return true;
				} else
					return false;
			} else
				return true;
		} else {
			if (Input.GetAxis (t_controller + "FireTrigger") == 0) {
				if (Input.GetButtonDown (t_controller + "FireButton")) {
					return true;
				} else
					return false;
			} else
				return true;
		}
	}

	public static bool Jump(string t_controller)
	{
		return Input.GetButtonDown (t_controller + "Jump");
	}

	public static float Horizontal(string t_controller)
	{
		return Input.GetAxis (t_controller + "Horizontal");
	}

	public static bool Cancel()
	{
		return Input.GetButtonUp ("Cancel");
	}
}
