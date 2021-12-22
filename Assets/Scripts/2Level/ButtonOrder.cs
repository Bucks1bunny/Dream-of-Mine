using System;
using UnityEngine;
using UnityEngine.Events;

public class ButtonOrder : Interactable
{

    public static int id;

    public Transform player;

    [SerializeField] private int pressRange;

    public UnityEvent OnButtonPressed;
    /*
    public override string ShowHand()
    {
        return "Press [<color=red>E</color>]";
    }
    */
    public override void Interact()
    {
        OnButtonPressed?.Invoke();
    }
    public static int SetID()
    {
        return id;
    }
    public static void GetID(int n)
    {
        id = n;
    }
}

