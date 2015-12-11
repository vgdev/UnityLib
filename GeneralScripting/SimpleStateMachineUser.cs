/*
*   Writen by: Jonathan Hunter
*   
*   Summary:  
*       This is a simple class for using a state machine class.
*
*/
using UnityEngine;

/// <summary> A MonoBehavior that uses the SimpleStateMachine to control its behavior. </summary>
public class SimpleStateMachineUser : MonoBehavior
{
    public bool a, b, c;

    private SimpleStateMachine machine;

    void Start()
    {
        //state machine init
        machine = new SimpleStateMachine();
    }

    void Update()
    {
        //get next state
        int currState = machine.update(a, b, c);

        //run state
        switch (currState)
        {
            case SimpleStateMachine.State.A: A(); break;
            case SimpleStateMachine.State.B: B(); break;
            case SimpleStateMachine.State.C: C(); break;
        }
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
