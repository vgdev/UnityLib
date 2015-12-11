/*
*   Writen by: Jonathan Hunter
*   
*   Summary:  
*       This is a simple class for building a state machine.  This one uses delegates.
*
*/

/// <summary> Simple State machine </summary>
class SimpleStateMachineStatic
{
    public enum State { A, B, C }

    private delegate State machine(bool a, bool b, bool c);
    private machine[] getNextState;
    private State currState;

    public SimpleStateMachineStatic()
    {
        currState = Enums.PlayerState.Idle;
        getNextState = new machine[] { A, B, C };
    }

    public Enums.PlayerState update(bool a, bool b, bool c)
    {
        return currState = getNextState[((int)currState)](a, b, c);
    }


    //The following methods control when and how you can transition between states

    private State A(bool a, bool b, bool c)
    {
        if (b)
            return State.B;
        if (c)
            return State.C;
        return State.A;
    }

    private State B(bool a, bool b, bool c)
    {
        if (a)
            return State.A;
        if (c)
            return State.C;
        return State.B;
    }

    private State C(bool a, bool b, bool c)
    {
        if (b)
            return State.B;
        if (a)
            return State.A;
        return State.C;
    }
}
