using UnityEngine;
using System.Collections;
using System;

public class PS4ControllerWrapper : ControllerInputWrapper 
{

	public PS4ControllerWrapper(int joyNum) : base(joyNum)
	{

	}

    public override float GetAxis(Axis axis, bool isRaw = false)
    {
        float scale = 1;
        string axisName = "";
        switch (axis)
        {
            case Axis.LeftStickX:
                axisName = getAxisName("X", "X", "X");
                break;
            case Axis.LeftStickY:
                axisName = getAxisName("Y", "Y", "Y");
                scale = -1;
                break;
            case Axis.RightStickX:
                axisName = getAxisName("3", "3", "3");
                break;
            case Axis.RightStickY:
                axisName = getAxisName("6", "4", "4");
                scale = -1;
                break;
			case Axis.DPadX:
				axisName = getAxisName("7", "7", "7");
				break;
			case Axis.DPadY:
				axisName = getAxisName("8", "8", "8");
				if(ControllerManager.instance.currentOS != ControllerManager.OperatingSystem.Win)
					scale = -1;
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

    public override bool GetButton(Buttons button)
    {
        string buttonName = GetButtonHelper(button);
		if(buttonName != null) {
	        return Input.GetButton(buttonName);
		}
		return false;
    }

	public override bool GetButtonDown(Buttons button)
	{
		string buttonName = GetButtonHelper(button);
		if(buttonName != null) {
			return Input.GetButtonDown(buttonName);
		}
		return false;
	}

    public override string GetButtonHelper(Buttons button)
    {
        string buttonName = "";
        switch (button)
        {
            case Buttons.A:
                buttonName = getButtonName("1", "1", "1");
                break;
            case Buttons.B:
                buttonName = getButtonName("2", "2", "2");
                break;
            case Buttons.X:
                buttonName = getButtonName("0", "0", "0");
                break;
            case Buttons.Y:
                buttonName = getButtonName("3", "3", "3");
                break;
            case Buttons.LeftBumper:
                buttonName = getButtonName("4", "4", "4");
                break;
            case Buttons.RightBumper:
                buttonName = getButtonName("5", "5", "5");
                break;
            case Buttons.LeftStickClick:
                buttonName = getButtonName("10", "10", "10");
                break;
            case Buttons.RightStickClick:
                buttonName = getButtonName("11", "11", "11");
                break;
            case Buttons.Start:
                buttonName = getButtonName("9", "9", "9");
                break;
			case Buttons.Back:
                buttonName = getButtonName("8", "8", "8");
                break;
        }
        return buttonName;
    }

    public override bool GetButtonUp(Buttons button)
    {
        string buttonName = GetButtonHelper(button);

        return Input.GetButtonUp(buttonName);
    }

    public override float GetTrigger(Triggers trigger, bool isRaw = false)
    {
        string triggerName = "";
        switch (trigger)
        {
            case Triggers.LeftTrigger:
                triggerName = getAxisName("4", "5", "5");
                break;
            case Triggers.RightTrigger:
                triggerName = getAxisName("5", "6", "6");
                break;
        }
        //Debug.Log(triggerName);
        if (isRaw)
        {
            return Input.GetAxisRaw(triggerName);
        }
        return Input.GetAxis(triggerName);

    }
}
