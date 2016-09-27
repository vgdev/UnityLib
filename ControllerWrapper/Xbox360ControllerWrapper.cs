using UnityEngine;
using System.Collections;
using System;

public class Xbox360ControllerWrapper : ControllerInputWrapper {

	public Xbox360ControllerWrapper(int joyNum) : base(joyNum)
	{
		
	}

    public override float GetAxis(Axis axis, bool isRaw = false)
    {
        string axisName = "";
        float scale = 1;

		if(ControllerManager.instance.currentOS == ControllerManager.OperatingSystem.OSX) {
			if(axis == Axis.DPadX) {
				if(Input.GetButton("j" + (joyNum + 1) + "_Button8")) {
					return 1;
				} else if(Input.GetButton("j" + (joyNum + 1) + "_Button7")) {
					return -1;
				}
				return 0;
			} else if(axis == Axis.DPadY) {
				if(Input.GetButton("j" + (joyNum + 1) + "_Button5")) {
					return 1;
				} else if(Input.GetButton("j" + (joyNum + 1) + "_Button6")) {
					return -1;
				}
				return 0;
			}
		}

        switch (axis)
        {
            case Axis.LeftStickX:
                axisName = getAxisName("X", "X", "X");
                break;
            case Axis.LeftStickY:
                scale = -1;
                axisName = getAxisName("Y", "Y", "Y");
                break;
            case Axis.RightStickX:
                axisName = getAxisName("4", "4", "3");
                break;
            case Axis.RightStickY:
                scale = -1;
                axisName = getAxisName("5", "5", "4");
                break;
			case Axis.DPadX:
				axisName = getAxisName("6", "", "");
				break;
			case Axis.DPadY:
				axisName = getAxisName("7", "", "");
				break;
        }
        if (isRaw)
        {
            return Input.GetAxisRaw(axisName) * scale;
        }
        else
        {
            return Input.GetAxis(axisName) * scale;
        }
    }

	public override string GetButtonHelper (Buttons button)
	{
		string buttonName = "";
		switch (button)
		{
		case Buttons.A:
			buttonName = getButtonName("0", "0", "16");
			break;
		case Buttons.B:
			buttonName = getButtonName("1", "1", "17");
			break;
		case Buttons.X:
			buttonName = getButtonName("2", "2", "18");
			break;
		case Buttons.Y:
			buttonName = getButtonName("3", "3", "19");
			break;
		case Buttons.RightBumper:
			buttonName = getButtonName("5", "5", "14");
			break;
		case Buttons.LeftBumper:
			buttonName = getButtonName("4", "4", "13");
			break;
		case Buttons.Start:
			buttonName = getButtonName("7", "7", "9");
			break;
		case Buttons.RightStickClick:
			buttonName = getButtonName("9", "10", "12");
			break;
		case Buttons.LeftStickClick:
			buttonName = getButtonName("8", "9", "11");
			break;
        case Buttons.Back:
            buttonName = getButtonName("6", "6", "10");
            break;
		}
		return buttonName;
	}

    public override bool GetButton(Buttons button)
    {
		string buttonName = GetButtonHelper(button);
        return Input.GetButton(buttonName);
    }


	public override bool GetButtonDown(Buttons button)
	{
		string buttonName = GetButtonHelper(button);
		return Input.GetButtonDown(buttonName);
	}
    

    public override bool GetButtonUp(Buttons button)
    {
        string buttonName = "";
        switch (button)
        {
            case Buttons.A:
                buttonName = getButtonName("0", "0", "16");
                break;
            case Buttons.B:
                buttonName = getButtonName("1", "1", "17");
                break;
            case Buttons.X:
                buttonName = getButtonName("2", "2", "18");
                break;
            case Buttons.Y:
                buttonName = getButtonName("3", "3", "19");
                break;
            case Buttons.RightBumper:
                buttonName = getButtonName("5", "5", "14");
                break;
            case Buttons.LeftBumper:
                buttonName = getButtonName("4", "4", "13");
                break;
            case Buttons.Start:
                buttonName = getButtonName("7", "7", "9");
                break;
            case Buttons.RightStickClick:
                buttonName = getButtonName("9", "10", "12");
                break;
            case Buttons.LeftStickClick:
                buttonName = getButtonName("8", "9", "11");
                break;
            case Buttons.Back:
                buttonName = getButtonName("6", "6", "10");
                break;
        }
        return Input.GetButtonUp(buttonName);
    }

    public override float GetTrigger(Triggers trigger, bool isRaw = false)
    {
		string axisName = "";
		if(ControllerManager.instance.currentOS == ControllerManager.OperatingSystem.Win) {
			axisName = getAxisName("3","","");
			switch (trigger)
            {
                case Triggers.LeftTrigger:
                    if (isRaw) return Mathf.Max(0, Input.GetAxisRaw(axisName));
                    else return Mathf.Max(0, Input.GetAxis(axisName));
                case Triggers.RightTrigger:
                    if (isRaw) return Mathf.Abs(Mathf.Min(0, Input.GetAxisRaw(axisName)));
                    else return Mathf.Abs(Mathf.Min(0, Input.GetAxis(axisName)));
            }
        } else {
	        switch (trigger)
	        {
	            case Triggers.LeftTrigger:
	                axisName = getAxisName("9", "3", "5");
	                break;
	            case Triggers.RightTrigger:
	                axisName = getAxisName("10", "6", "6");
	                break;
	        }
	        if (isRaw)
	        {
	            return Input.GetAxisRaw(axisName);
	        }
	        else
	        {
	            return Input.GetAxis(axisName);
	        }
		}
        return 0;
    }
}
