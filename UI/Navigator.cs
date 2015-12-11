/*
*   Writen by: Eric Cook
*   Originally used in:  https://github.com/JonathanHunter/CardNinjas
*   
*   Summary:  
*       Universal naivagtion class allowing the fir=ing of unity UI navigation events from a C# script.
*       This allows you to easily have you menus navigable by keyboard/controller and mouse.
*
*   Example use:
*       // Player hits left
*       if(CustomInput.BoolsFreshPress(CustomInput.UserInput.Left, 0))
*       {
*           Navigator.Navigate(Direction.Left, CurrentDefault);
*       }
*
*/
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Assets.Scripts.Util;

public static class Navigator
{
    /// <summary> Enum for selecting the direction to move. </summary>
    public enum Direction { Up, Down, Left, Right }

    /// <summary> Tells the Unity UI navigation system to move in the spoecified direction. </summary>
    /// <param name="direction"> The direction to move in. </param>
    /// <param name="defaultGameObject"> The GameObject to select in there is no valid object in that direction. </param>
    public static void Navigate(Direction direction, GameObject defaultGameObject)
    {
        GameObject next = EventSystem.current.currentSelectedGameObject;
        if (next == null)
        {
            if (defaultGameObject != null) EventSystem.current.SetSelectedGameObject(defaultGameObject);
            return;
        }

        bool nextIsValid = false;
        while (!nextIsValid)
        {
            switch (direction)
            {
                case Direction.Up:
                    if (EventSystem.current.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp() != null)
                        next = EventSystem.current.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp().gameObject;
                    else next = null;
                    break;
                case Direction.Down:
                    if (EventSystem.current.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown() != null)
                        next = EventSystem.current.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown().gameObject;
                    else next = null;
                    break;
                case Direction.Left:
                    if (EventSystem.current.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnLeft() != null)
                        next = EventSystem.current.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnLeft().gameObject;
                    else next = null;
                    break;
                case Direction.Right:
                    if (EventSystem.current.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnRight() != null)
                        next = EventSystem.current.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnRight().gameObject;
                    else next = null;
                    break;
            }
            if (next != null)
            {
                EventSystem.current.SetSelectedGameObject(next);
                nextIsValid = next.GetComponent<Selectable>().interactable;
            }
            else nextIsValid = true;
        }
    }

    /// <summary> Executes a Unity UI navigation submit Event. </summary>
    public static void CallSubmit()
    {
        var pointer = new PointerEventData(EventSystem.current);
        ExecuteEvents.Execute(EventSystem.current.currentSelectedGameObject, pointer, ExecuteEvents.submitHandler);
    }
}