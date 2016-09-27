using UnityEngine;
using System.Collections;
using System;

public class LogitechControllerWrapper : ControllerInputWrapper 
{

	public LogitechControllerWrapper(int joyNum) : base(joyNum)
	{
		
	}

    public override float GetAxis(Axis axis, bool isRaw = false)
    {
        string axisName = "";

        switch (axis)
        {
            case Axis.LeftStickX:
                axisName = getAxisName("X", "X", "X");
                break;
            case Axis.LeftStickY:
                axisName = getAxisName("Y", "Y", "Y");
                break;
            case Axis.RightStickX:
                axisName = getAxisName("3", "3", "3");
                break;
            case Axis.RightStickY:
                axisName = getAxisName("4", "4", "4");
                break;
        }

        if (isRaw)
        {
            return Input.GetAxisRaw(axisName);
        }
        return Input.GetAxis(axisName);
    }

    public override float GetTrigger(Triggers trigger, bool isRaw = false)
    {
        string triggerName = "";
        switch (trigger)
        {
            case Triggers.LeftTrigger:
                triggerName = getButtonName("6", "6", "6");
                break;
            case Triggers.RightTrigger:
                triggerName = getButtonName("7", "7", "7");
                break;
        }

        if (Input.GetButton(triggerName))
        {
            return 1;
        }
        return 0;
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

    public override bool GetButtonUp(Buttons button)
    {
        string buttonName = GetButtonHelper(button);
        return Input.GetButtonUp(buttonName);
    }

    public override string GetButtonHelper(Buttons button)
    {
        switch (button)
        {
            case Buttons.A:
                return getButtonName("1", "1", "1");
            case Buttons.B:
                return getButtonName("2", "2", "2");
            case Buttons.X:
                return getButtonName("0", "0", "0");
            case Buttons.Y:
                return getButtonName("3", "3", "3");
            case Buttons.RightBumper:
                return getButtonName("5", "5", "5");
            case Buttons.LeftBumper:
                return getButtonName("4", "4", "4");
            case Buttons.Start:
                return getButtonName("9", "9", "9");
            case Buttons.Back:
                return getButtonName("8", "8", "8");
        }
        return "";
    }
}
