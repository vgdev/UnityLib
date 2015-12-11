/*
*   Writen by: Jonathan Hunter
*   
*   Summary:  
*       This is a simple class for using a state machine class.  This one uses delegates.
*
*/
using UnityEngine;

/// <summary> A MonoBehavior that uses the SimpleStateMachine to control its behavior. </summary>
public class SimpleStateMachineStaticUser : MonoBehavior
{
    public bool a, b, c;

    private SimpleStateMachineStatic machine;
    private delegate void state();
    private state[] doState;

    void Start()
    {
        //state machine init
        machine = new SimpleStateMachine();
        doState = new state[] { A, B, C };
    }

    void Update()
    {
        //get next state
        int state = (int)machine.update(a, b, c);
        //run state
        doState[state]();
    }

    private void A()
    {
        // Do A
    }

    private void B()
    {
        // Do B
    }

    private void C()
    {
        // Do C
    }
}
