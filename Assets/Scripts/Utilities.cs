using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    public static string ChangeStringColor(string stringToChange, string valueInHexOf4Bytes)
    {
        return "<color=#" + valueInHexOf4Bytes + ">" + stringToChange + "</color>";
    }
    static public void FreezeGameObject(GameObject gameObjectToFreeze)
    {
        //Component[] components = gameObjectToFreeze.GetComponents(typeof(Component));
        //foreach (var component in components)
        //{
        //    Animator animator = component.GetComponent<Animator>();
        //    if (animator != null)
        //    {
        //        animator.speed = 0;
        //    }
        //    else
        //    {
        //        component.
        //    }
        //}
    }
}
