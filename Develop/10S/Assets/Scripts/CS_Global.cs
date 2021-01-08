using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public static class CS_Global {

	public static float GRAVITY = 9.81f;

	public static float SPEED_HORIZONTAL = 2.0f;
	public static float SPEED_JUMP = 6.0f;
	public static float SPEED_RATE_WALK = 1.0f;
	public static float SPEED_RATE_BIKE = 2.0f;
	public static float SPEED_CAMERA = 2.0f;

	public static float ROTATION_DEADBODY = 60.0f;

	public static float POSITION_PLAYER_Z = 0;
	public static float POSITION_PORTAL_DY = 0.5f;
	public static float POSITION_PORTAL_Z = 2.4f;
	public static float POSITION_DOOR_Z = 2.4f;
	public static float POSITION_DEADBODY_Z = 1;
	public static float POSITION_TOOL_Z = -1;
	public static float POSITION_ELEVATORBTN_Z = 2.4f;

	public static int AMOUNT_STAGES = 4;

	public static int SAVE_LEVEL_LOCKED = 0;
	public static int SAVE_LEVEL_UNDONE = 1;
	public static int SAVE_LEVEL_DONE = 2;
	public static int SAVE_LEVEL_PERFECT = 3;

	public static string TAG_UNTAGGED = "Untagged";
	public static string TAG_TOOL = "Tool";
	public static string TAG_DEADBODY = "DeadBody";
	public static string TAG_PLAYER = "Player";
	public static string TAG_TERRACOTTAARMY = "TerracottaArmy";

	public static int TOOL_NULL = 0;
	public static int TOOL_BOTTLE = 1;
	public static int TOOL_BIKE = 2;
	public static int TOOL_BALL = 3;
	public static int TOOL_PORTAL = 4;
	public static int TOOL_SHOES = 5;
	public static int TOOL_FLOWER = 6;
	public static int TOOL_GLOVES = 7;
	public static int TOOL_HAMMER = 8;

	public static float TIME_DRUG = 13;
	public static float TIME_START = 10;
	public static float TIME_END = 0;
	public static float TIME_RESTART = -1;

	
	public static string NAME_MESSAGEBOX = "MessageBox";
	public static string NAME_TRANSITIONMANAGER = "TransitionManager";
	public static string NAME_PLAYER = "Player";
	public static string NAME_TIMER = "Timer";
	public static string NAME_PLAYERPOCKRT = "PlayerPocket";
	public static string NAME_WOMB = "Womb";
	public static string NAME_DEADBODYMANUFACTORY = "DeadBodyManufactory";
	public static string NAME_ELEVATORMANAGER = "ElevatorManager";
	public static string NAME_ELEVATORCAVE = "ElevatorCave";
	public static string NAME_ELEVATORBOTTON_F1 = "ElevatorBotton_F1";
	public static string NAME_ELEVATORBOTTON_F2 = "ElevatorBotton_F2";
	public static string NAME_ELEVATORBOTTON_INSIDE = "ElevatorBotton_Inside";
	public static string NAME_BOTTON_NEXT = "BtnNext";
	public static string NAME_BOTTON_MENU = "BtnMenu";
	public static string NAME_BOTTON_AGAIN = "BtnAgain";
	public static string NAME_DEATHCOUNT_PERFECT = "DeathCountPerfect";
	public static string NAME_DEATHCOUNT_YOURS = "DeathCountYours";
	public static string NAME_PASS_CLEAR = "Clear";
	public static string NAME_PASS_PERFECT = "Perfect";
	public static string NAME_PASS_PERFECTHEART = "PerfectHeart";
	public static string NAME_GUIDEMANAGER = "GuideManager";
	public static string NAME_UI_TIMER = "UI_Timer";
	public static string NAME_MOM = "Mom";


	public static int FLOOR_1 = 1;
	public static int FLOOR_2 = 2;
	public static int ELEVATOR_INSIDE = 9;

	public static float DISTANCE_MOVE = 0.1f;
	public static float DISTANCE_BIRD = 1.0f;
	public static float DISTANCE_GET_TOOL = 0.5f;
	public static float DISTANCE_GET_TOOL_Y = 2.0f;
	public static float DISTANCE_WARNING = 2f;
	public static float DISTANCE_USE_PORTAL = 3.0f;
	public static float DISTANCE_PRESS_BUTTON = 3.2f;
	public static float DISTANCE_SHADOW = 0.01f;

	public static string BOTTLE_LOCKED = "0";
	public static string BOTTLE_UNDO = "1";
	public static string BOTTLE_DONE = "2";
	public static string BOTTLE_PERFECT = "3";

	public static int[] PERFECT_STAGE1 = {0,0,1,0,1,1,2,3,9,9};
	public static int[] PERFECT_STAGE2 = {1,1,1,1,2,0,2,3,9,9};
	public static int[] PERFECT_STAGE3 = {0,1,1,1,1,2,2,3,9,0};
	public static int[] PERFECT_STAGE4 = {1,2,3,4,5,6,7,8,9,0};

	public static Vector3 EULER_ANGLES_BL = new Vector3 (0, 0, 0);
	public static Vector3 EULER_ANGLES_BR = new Vector3 (0, 180, 0);
	public static Vector3 EULER_ANGLES_TL = new Vector3 (180, 0, 0);
	public static Vector3 EULER_ANGLES_TR = new Vector3 (0, 0, 180);

	public static IEnumerator DelayToInvokeDo(Action action, float delaySeconds)
	{
		//http://www.myext.cn/other/a_25720.html

		yield return new WaitForSeconds(delaySeconds);
		action();
	}

//	void OnClick()
//	{
//		StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
//			{
//				Application.LoadLevel(“Option”);
//			}, 0.1f));
//	}
}
