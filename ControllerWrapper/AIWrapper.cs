/// <summary>
/// Dummy controller for AI to avoid using a null controller reference.
/// </summary>
public class AIWrapper : ControllerInputWrapper
{

	/// <summary>
	/// Initializes an AI controller wrapper.
	/// </summary>
	/// <param name="joyNum">Unused.</param>
	public AIWrapper(int joyNum) : base(joyNum)
	{
	}

	/// <summary>
	/// Does nothing.
	/// </summary>
	/// <returns>False.</returns>
	/// <param name="button">Unused.</param>
	public override bool GetButton(Buttons button)
	{
		return false;
	}

	/// <summary>
	/// Does nothing.
	/// </summary>
	/// <returns>False.</returns>
	/// <param name="button">Unused.</param>
	public override bool GetButtonDown(Buttons button)
	{
		return false;
	}

	/// <summary>
	/// Does nothing.
	/// </summary>
	/// <returns>False.</returns>
	/// <param name="button">Unused.</param>
	public override bool GetButtonUp(Buttons button)
	{
		return false;
	}

	/// <summary>
	/// Does nothing.
	/// </summary>
	/// <returns>0.</returns>
	/// <param name="axis">Unused.</param>
	/// <param name="isRaw">Unused.</param>
	public override float GetAxis(Axis axis, bool isRaw = false)
	{
		return 0;
	}

	/// <summary>
	/// Does nothing.
	/// </summary>
	/// <returns>0.</returns>
	/// <param name="trigger">Unused.</param>
	/// <param name="isRaw">Unused.</param>
	public override float GetTrigger(Triggers trigger, bool isRaw = false)
	{
		return 0;
	}

	/// <summary>
	/// Does nothing.
	/// </summary>
	/// <returns>An empty string.</returns>
	/// <param name="button">Unused.</param>
	public override string GetButtonHelper(Buttons button)
	{
		return "";
	}
}
