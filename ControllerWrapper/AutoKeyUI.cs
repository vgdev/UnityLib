using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AutoKeyUI : MonoBehaviour {

	public PlayerID id = PlayerID.None;

	private PlayerID prevID = PlayerID.None;

	private ControllerManager.ControlType prevControlType = ControllerManager.ControlType.None;

	private enum Type {Button, Axis, Trigger, DPAD, LJOY, RJOY};

	[SerializeField]
	private Type type;
	public ControllerInputWrapper.Buttons button;
	public ControllerInputWrapper.Axis axis;
	public ControllerInputWrapper.Triggers trigger;

	private bool uiImage = false;

	// Use this for initialization
	void OnEnable () {
		if(GetComponent<Image>() != null) uiImage = true;
//		if(uiImage) GetComponent<Image>().sprite = null;
//		else GetComponent<SpriteRenderer>().sprite = null;

	}
	
	// Update is called once per frame
	void Update () {

		if(ControllerManager.instance.NumPlayers < (int)id) return;
		if(id == PlayerID.None) {
			if(!uiImage) GetComponent<SpriteRenderer>().sprite = null;
			
			prevControlType = ControllerManager.ControlType.None;
		}
		if(prevID == id && prevControlType == ControllerManager.instance.PlayerControlType(id)) return;

		prevID = id;
		prevControlType = ControllerManager.instance.PlayerControlType(id);

		switch(type) {
		case Type.Axis:
			switch(axis) {
			case ControllerInputWrapper.Axis.DPadX:
				switch(ControllerManager.instance.PlayerControlType(id)) {
				case ControllerManager.ControlType.Keyboard:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.KEY_LEFTRIGHT;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.KEY_LEFTRIGHT;
					}
					break;
				case ControllerManager.ControlType.Xbox:
				case ControllerManager.ControlType.PS4:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.DPAD_LEFTRIGHT;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.DPAD_LEFTRIGHT;
					}
					break;
				}
				break;
			case ControllerInputWrapper.Axis.DPadY:

				break;
			case ControllerInputWrapper.Axis.LeftStickX:

				break;
			case ControllerInputWrapper.Axis.LeftStickY:
				switch(ControllerManager.instance.PlayerControlType(id)) {
				case ControllerManager.ControlType.Keyboard:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.KEY_UPDOWNLEFTRIGHT;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.KEY_UPDOWNLEFTRIGHT;
					}
					break;
				case ControllerManager.ControlType.Xbox:
				case ControllerManager.ControlType.PS4:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.JOYLEFT;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.JOYLEFT;
					}
					break;
				}
				break;
			case ControllerInputWrapper.Axis.RightStickX:

				break;
			case ControllerInputWrapper.Axis.RightStickY:

				break;
			}
			break;
		case Type.Button:
			switch(button) {
			case ControllerInputWrapper.Buttons.A:
				switch(ControllerManager.instance.PlayerControlType(id)) {
				case ControllerManager.ControlType.Keyboard:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.KEY_A;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.KEY_A;
					}
					break;
				case ControllerManager.ControlType.Xbox:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.XBOX_A;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.XBOX_A;
					}
					break;
				case ControllerManager.ControlType.PS4:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.PS4_A;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.PS4_A;
					}
					break;
				}
				break;
			case ControllerInputWrapper.Buttons.B:
				switch(ControllerManager.instance.PlayerControlType(id)) {
				case ControllerManager.ControlType.Keyboard:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.KEY_B;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.KEY_B;
					}
					break;
				case ControllerManager.ControlType.Xbox:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.XBOX_B;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.XBOX_B;
					}
					break;
				case ControllerManager.ControlType.PS4:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.PS4_B;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.PS4_B;
					}
					break;
				}
				break;
			case ControllerInputWrapper.Buttons.LeftStickClick:
				switch(ControllerManager.instance.PlayerControlType(id)) {
				case ControllerManager.ControlType.Keyboard:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.KEY_L_JOY_CLICK;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.KEY_L_JOY_CLICK;
					}
					break;
				case ControllerManager.ControlType.PS4:
				case ControllerManager.ControlType.Xbox:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.L_JOY_CLICK;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.L_JOY_CLICK;
					}
					break;
				}
				break;
			case ControllerInputWrapper.Buttons.RightBumper:
				switch(ControllerManager.instance.PlayerControlType(id)) {
				case ControllerManager.ControlType.Keyboard:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.KEY_RB;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.KEY_RB;
					}
					break;
				case ControllerManager.ControlType.PS4:
				case ControllerManager.ControlType.Xbox:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.RB;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.RB;
					}
					break;
				}
				break;
			case ControllerInputWrapper.Buttons.LeftBumper:
				switch(ControllerManager.instance.PlayerControlType(id)) {
				case ControllerManager.ControlType.Keyboard:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.KEY_LB;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.KEY_LB;
					}
					break;
				case ControllerManager.ControlType.PS4:
				case ControllerManager.ControlType.Xbox:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.LB;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.LB;
					}
					break;
				}
				break;
			case ControllerInputWrapper.Buttons.RightStickClick:
				switch(ControllerManager.instance.PlayerControlType(id)) {
				case ControllerManager.ControlType.Keyboard:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.KEY_R_JOY_CLICK;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.KEY_R_JOY_CLICK;
					}
					break;
				case ControllerManager.ControlType.PS4:
				case ControllerManager.ControlType.Xbox:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.R_JOY_CLICK;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.R_JOY_CLICK;
					}
					break;
				}
				break;
			case ControllerInputWrapper.Buttons.Start:
				switch(ControllerManager.instance.PlayerControlType(id)) {
				case ControllerManager.ControlType.Keyboard:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.KEY_START;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.KEY_START;
					}
					break;
				case ControllerManager.ControlType.Xbox:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.XBOX_START;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.XBOX_START;
					}
					break;
				case ControllerManager.ControlType.PS4:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.PS4_START;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.PS4_START;
					}
					break;
				}
				break;
			case ControllerInputWrapper.Buttons.X:
				switch(ControllerManager.instance.PlayerControlType(id)) {
				case ControllerManager.ControlType.Keyboard:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.KEY_X;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.KEY_X;
					}
					break;
				case ControllerManager.ControlType.Xbox:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.XBOX_X;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.XBOX_X;
					}
					break;
				case ControllerManager.ControlType.PS4:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.PS4_X;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.PS4_X;
					}
					break;
				}
				break;
			case ControllerInputWrapper.Buttons.Y:
				switch(ControllerManager.instance.PlayerControlType(id)) {
				case ControllerManager.ControlType.Keyboard:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.KEY_Y;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.KEY_Y;
					}
					break;
				case ControllerManager.ControlType.Xbox:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.XBOX_Y;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.XBOX_Y;
					}
					break;
				case ControllerManager.ControlType.PS4:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.PS4_Y;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.PS4_Y;
					}
					break;
				}
				break;
			case ControllerInputWrapper.Buttons.Back:
				switch(ControllerManager.instance.PlayerControlType(id)) {
				case ControllerManager.ControlType.Keyboard:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.KEY_BACK;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.KEY_BACK;
					}
					break;
				case ControllerManager.ControlType.Xbox:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.XBOX_BACK;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.XBOX_BACK;
					}
					break;
				case ControllerManager.ControlType.PS4:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.PS4_BACK;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.PS4_BACK;
					}
					break;
				}
				break;
			}
			break;
		case Type.Trigger:
			switch(trigger) {
			case ControllerInputWrapper.Triggers.RightTrigger:
				switch(ControllerManager.instance.PlayerControlType(id)) {
				case ControllerManager.ControlType.Keyboard:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.KEY_RT;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.KEY_RT;
					}
					break;
				case ControllerManager.ControlType.Xbox:
				case ControllerManager.ControlType.PS4:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.RT;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.RT;
					}
					break;
				}
				break;
			case ControllerInputWrapper.Triggers.LeftTrigger:
				switch(ControllerManager.instance.PlayerControlType(id)) {
				case ControllerManager.ControlType.Keyboard:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.KEY_LT;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.KEY_LT;
					}
					break;
				case ControllerManager.ControlType.Xbox:
				case ControllerManager.ControlType.PS4:
					if(uiImage) {
						GetComponent<Image>().sprite = InputTester.instance.LT;
					} else {
						GetComponent<SpriteRenderer>().sprite = InputTester.instance.LT;
					}
					break;
				}
				break;
			}
			break;
		case Type.DPAD:
			switch(ControllerManager.instance.PlayerControlType(id)) {
			case ControllerManager.ControlType.Keyboard:
				if(uiImage) {
					GetComponent<Image>().sprite = InputTester.instance.KEY_UPDOWNLEFTRIGHT;
				} else {
					GetComponent<SpriteRenderer>().sprite = InputTester.instance.KEY_UPDOWNLEFTRIGHT;
				}
				break;
			case ControllerManager.ControlType.PS4:
			case ControllerManager.ControlType.Xbox:
				if(uiImage) {
					GetComponent<Image>().sprite = InputTester.instance.DPAD_LEFTRIGHTUPDOWN;
				} else {
					GetComponent<SpriteRenderer>().sprite = InputTester.instance.DPAD_LEFTRIGHTUPDOWN;
				}
				break;
			}
			break;
		}
	}


}
