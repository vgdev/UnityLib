using UnityEngine;
using UnityEngine.SceneManagement;

public class InputTester : MonoBehaviour {

	/// <summary>
	/// Probably going to be changed later, mostly unnecessary -Kartik
	/// </summary>
	public static InputTester instance;

	//Handles Auto Input UI
	public Sprite XBOX_A, PS4_A, KEY_A, XBOX_B, PS4_B, KEY_B, XBOX_START, PS4_START, KEY_START, JOYLEFT, DPAD_LEFTRIGHT, DPAD_LEFTRIGHTUPDOWN, KEY_UPDOWNLEFTRIGHT,KEY_LEFTRIGHT;
	public Sprite L_JOY_CLICK, KEY_L_JOY_CLICK, R_JOY_CLICK, KEY_R_JOY_CLICK, XBOX_X, PS4_X, KEY_X, XBOX_Y, PS4_Y, KEY_Y, XBOX_BACK, PS4_BACK, KEY_BACK;
	public Sprite RB, LB, KEY_RB, KEY_LB, RT, LT, KEY_RT, KEY_LT;

	private ControllerManager cm;

    void Awake()
    {
        if (instance == null)
        {
			DontDestroyOnLoad(this);
            instance = this;
            cm = new ControllerManager();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

	//Test code that allows at least one player to be added
	void Update() {
		if(cm.NumPlayers < 1) {
			cm.AddPlayer(ControllerInputWrapper.Buttons.Start);
		}
	}


}
