using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum PlayerID {None, One, Two, Three, Four};

public class ControllerManager  {

	public enum ControlType { None, Xbox, PS4, Keyboard };
	public enum OperatingSystem { Win, OSX, Linux };

	public OperatingSystem currentOS;
	public Dictionary<PlayerID, ControllerInputWrapper> playerControls;

	public static ControllerManager instance;

	public const float CUSTOM_DEADZONE = 0.15f;

	public ControllerManager()
	{
		setUpPlatform();
		playerControls = new Dictionary<PlayerID, ControllerInputWrapper>();
		if(instance != this) {
			instance = this;
		}
	}

	public void ClearPlayers()
	{
		playerControls = new Dictionary<PlayerID, ControllerInputWrapper>();
	}

	public int NumPlayers {
		get {
			return playerControls.Count;
		}
	}

	public ControlType PlayerControlType(PlayerID id) {
		if(!playerControls.ContainsKey(id)) return ControlType.None;
		if(playerControls[id].GetType().Equals(typeof(Xbox360ControllerWrapper))
			|| playerControls[id].GetType().Equals(typeof(XboxOneControllerWrapper))) {
			return ControlType.Xbox;
		} else if(playerControls[id].GetType().Equals(typeof(PS4ControllerWrapper))
			|| playerControls[id].GetType().Equals(typeof(PS3ControllerWrapper))) {
			return ControlType.PS4;
		}  else if(playerControls[id].GetType().Equals(typeof(KeyboardWrapper))) {
			return ControlType.Keyboard;
		} else {
			return ControlType.None;
		}
	}

	public void ResetInputs() {
		playerControls = new Dictionary<PlayerID, ControllerInputWrapper>();
	}

	public bool AddPlayer(ControllerInputWrapper.Buttons connectCode) {
		KeyboardWrapper kw = new KeyboardWrapper(-1);
		if(!playerControls.ContainsValue(kw) && kw.GetButton(connectCode)) {
			for(int j = 1; j < 5; j++) {
				if(!playerControls.ContainsKey((PlayerID)j)) {
					RegisterPlayerController(j, kw);
					return true;
				}
			}
		}
		if(playerControls.Count < 4) {
			string[] controllerNames = Input.GetJoystickNames();
			for (int i = 0; i < controllerNames.Length; i++) {
				ControllerInputWrapper ciw = getControllerType(i);
				if(ciw != null && !playerControls.ContainsValue(ciw) && ciw.GetButton(connectCode)) {
					for(int j = 1; j < 5; j++) {
						if(!playerControls.ContainsKey((PlayerID)j)) {
							RegisterPlayerController(j, ciw);
							return true;
						}
					}
				}
			}
		}

		return false;
	}

	/// <summary>
	/// Registers a player in the controls map.
	/// </summary>
	/// <param name="id">The ID of the player being registered. </param>
	/// <param name="ciw">The controller being registered. </param>
	private void RegisterPlayerController(int id, ControllerInputWrapper ciw) {
		if (IsAllAI()) {
			for (int i = NumPlayers; i > 0; i--) {
				PlayerID currentID = (PlayerID)i;
				ControllerInputWrapper controller = playerControls[currentID];
				playerControls.Remove(currentID);
				if (i < 4) {
					playerControls.Add((PlayerID)(i + 1), controller);
				}
			}
			id = 1;
		}
		playerControls.Add((PlayerID)(id), ciw);
		Debug.Log((PlayerID)(id) + ": " + ciw + " added");
	}

	/// <summary>
	/// Adds an AI controller to the game.
	/// </summary>
	/// <returns>Whether the AI controller was successfully added.</returns>
	public bool AddAI(ControllerInputWrapper.Buttons connectCode) {
		if (playerControls.Count < 4) {
			foreach(KeyValuePair<PlayerID, ControllerInputWrapper> kvp in ControllerManager.instance.playerControls) {
				ControllerInputWrapper ciw = kvp.Value;
				if (ciw != null && ciw.GetButton(connectCode)) {
					for (int j = 1; j < 5; j++) {
						if (!playerControls.ContainsKey((PlayerID)j)) {
							AIWrapper aiw = new AIWrapper(-2);
							playerControls.Add((PlayerID)(j), aiw);
							Debug.Log((PlayerID)(j) + ": " + aiw + " added");
							return true;
						}
					}
				}
			}
		}
		return false;
	}

	public int AllowPlayerRemoval(ControllerInputWrapper.Buttons removalButton) {
		PlayerID playerToRemove = PlayerID.None;
		foreach(KeyValuePair<PlayerID, ControllerInputWrapper> kvp in playerControls) {
			if(kvp.Value.GetButton(removalButton)) {
				playerToRemove = kvp.Key;
				break;
			}
		}
		if(playerToRemove != PlayerID.None) {
			RemoveController(playerToRemove);
		}
		return (int)playerToRemove;
	}

	/// <summary>
	/// Removes the last AI player from the game.
	/// </summary>
	/// <returns>The index of the AI player that was removed.</returns>
	/// <param name="removalButton">The button that needs to be pressed to remove an AI.</param>
	public int AllowAIRemoval(ControllerInputWrapper.Buttons removalButton) {
		PlayerID playerToRemove = PlayerID.None;
		bool removing = false;
		foreach(KeyValuePair<PlayerID, ControllerInputWrapper> kvp in playerControls) {
			if(kvp.Value.GetButton(removalButton)) {
				removing = true;
				break;
			}
		}
		if(removing) {
			foreach(KeyValuePair<PlayerID, ControllerInputWrapper> kvp in playerControls) {
				if(kvp.Value is AIWrapper && kvp.Key > playerToRemove) {
					playerToRemove = kvp.Key;
				}
			}
		}
		if(playerToRemove != PlayerID.None) {
			RemoveController(playerToRemove);
		}
		return (int)playerToRemove;
	}

	/// <summary>
	/// Removes a controller from the controller list and shifts over any controllers past it.
	/// </summary>
	/// <param name="playerToRemove">The ID of the controller to remove.</param>
	private void RemoveController(PlayerID playerToRemove) {
		playerControls.Remove(playerToRemove);
		if ((int)playerToRemove <= NumPlayers) {
			// Shift all players after the removed player back one place.
			for (int i = (int)playerToRemove + 1; i <= NumPlayers + 1; i++) {
				PlayerID currentID = (PlayerID)i;
				ControllerInputWrapper controller = playerControls[currentID];
				playerControls.Remove(currentID);
				playerControls.Add((PlayerID)(i - 1), controller);
			}
		}
	}

	/// <summary>
	/// Checks if the player with the given ID is an AI player.
	/// </summary>
	/// <returns>Whether the player with the given ID is an AI player.</returns>
	/// <param name="id">The ID of the player to check.</param></param>
	public bool IsAI(PlayerID id) {
		if(playerControls.ContainsKey(id))
			return playerControls[id] is AIWrapper;
		return false;
	}

	/// <summary>
	/// Checks if only AI players are registered.
	/// </summary>
	/// <returns>Whether only AI players are registered.</returns>
	private bool IsAllAI() {
		if (NumPlayers == 0) {
			return false;
		}
		foreach (ControllerInputWrapper controller in playerControls.Values) {
			if (!(controller is AIWrapper)) {
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// Counts the number of registered AI players.
	/// </summary>
	/// <returns>The number of registered AI players.</returns>
	public int CountAI() {
		int numAI = 0;
		foreach (ControllerInputWrapper controller in playerControls.Values) {
			if (controller is AIWrapper) {
				numAI++;
			}
		}
		return numAI;
	}

	public ControllerInputWrapper getControllerType(int joyNum)
	{
		string[] controllerNames = Input.GetJoystickNames();
		if (joyNum < 0 || joyNum > controllerNames.Length)
		{
			return null;
		}
		//        joyNum--;
		string name = controllerNames[joyNum];

		if (name.Contains("Wireless"))
		{
			return new PS4ControllerWrapper(joyNum);
		}
		else if (name.Contains("Logitech"))
		{
			return new LogitechControllerWrapper(joyNum);
		}
		else if (name.Contains("360"))
		{
			return new Xbox360ControllerWrapper(joyNum);
		}
		else
		{
			return new XboxOneControllerWrapper(joyNum);
		}


	}

	private void setUpPlatform()
	{
		//Debug.Log ("platform: " + Application.platform);
		if (Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXWebPlayer 
			|| Application.platform == RuntimePlatform.OSXEditor)
		{
			currentOS = OperatingSystem.OSX;
		}
		else
		{
			currentOS = OperatingSystem.Win;
		}
	}

	/// <summary>
	/// Checks if the controller with a certain ID is an AI controller.
	/// </summary>
	/// <returns>Whether the controller with the given ID is an AI controller.</returns>
	/// <param name="id">The ID of the controller to check.</param>
	public bool IsAIController(PlayerID id) {
		ControllerInputWrapper controller;
		if (playerControls.TryGetValue(id, out controller)) {
			return controller is AIWrapper;
		}
		return false;
	}

	public float GetAxis(ControllerInputWrapper.Axis axis, PlayerID id, bool isRaw = false)
	{
		if(!playerControls.ContainsKey(id)) return 0;
		if (playerControls[id] == null)
		{
			return 0;
		}
		return playerControls[id].GetAxis(axis, isRaw);
	}

	public float GetTrigger(ControllerInputWrapper.Triggers trigger, PlayerID id, bool isRaw = false)
	{
		if(!playerControls.ContainsKey(id)) return 0;
		if (playerControls[id] == null)
		{
			return 0;
		}
		return playerControls[id].GetTrigger(trigger, isRaw);
	}

	public bool GetButton(ControllerInputWrapper.Buttons button, PlayerID id = PlayerID.One)
	{
		if(!playerControls.ContainsKey(id)) return false;
		if (playerControls[id] == null)
		{
			return false;
		}
		return playerControls[id].GetButton(button);
	}

	public bool GetButtonDown(ControllerInputWrapper.Buttons button, PlayerID id = PlayerID.One) {
		if(!playerControls.ContainsKey(id)) return false;
		if (playerControls[id] == null)
		{
			return false;
		}
		return playerControls[id].GetButtonDown(button);
	}

	public bool GetButtonUp(ControllerInputWrapper.Buttons button, PlayerID id = PlayerID.One)
	{
		if(!playerControls.ContainsKey(id)) return false;
		if (playerControls[id] == null)
		{
			return false;
		}
		return playerControls[id].GetButtonUp(button);
	}

	public override string ToString ()
	{
		return currentOS.ToString(); 
	}
}
