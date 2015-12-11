/*
*   Writen by: Jonathan Hunter
*   
*   Summary:  
*       This is a simple class for building a state machine.
*
*/

/// <summary> Simple State machine </summary>
class SimpleStateMachine
{
    public enum State {  A, B, C }

    private State currState;

    public SimpleStateMachine()
    {
        currState = Enums.PlayerState.Idle;
    }
        
    public Enums.PlayerState update(bool a, bool b, bool c)
    {
        switch (currState)
        {
            case Enums.PlayerState.A: currState = A(a, b, c); break;
            case Enums.PlayerState.B: currState = B(a, b, c); break;
            case Enums.PlayerState.C: currState = C(a, b, c); break;
        }
        return currState;
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
