using System;
using UnityEngine;
using UnityEngine.Events;

public class ButtonOrder : MonoBehaviour,IInteractable
{

    public static int id;

    public Transform player;

    [SerializeField] private int pressRange;

    public UnityEvent OnButtonPressed;
    public void Interact()
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

