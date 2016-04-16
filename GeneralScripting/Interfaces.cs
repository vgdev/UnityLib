/*
*   Writen by: Eric Cook
*   
*   Summary:  
*       Simple script for detecting if a class implements a specified interface
*
*   Example use:
*   
*       Animal a = new Animal();
*       if(Interfaces.ImplementsInterface(a.GetType(), typeof(ICarnivore))
*           // eat that other thing
*       else if(Interfaces.ImplementsInterface(a.GetType(), typeof(IHerbivore))
*           // don't eat that other thing, have a salad instead
*
*/

using System;
using System.Linq;

/// <summary>
/// Generic class for dealing with interfaces
/// </summary>
public static class Interfaces
{
    /// <summary>
    /// Checks to see if a spcific class type implements an interface
    /// </summary>
    /// <param name="type">The type of the class to check</param>
    /// <param name="iType">The type of the interface to chack against</param>
    /// <returns>True if the class implements the interface</returns>
    public static bool ImplementsInterface(Type type, Type iType)
    {
        // Uses a predicate with System.Linq to check if an interface exists within the interfaces of the object
        return type.GetInterfaces().Any(t => t == iType);
    }
}