using System;
using UnityEngine;
using UnityEngine.Events;

public class ButtonOrder : MonoBehaviour
{
    //Raycast
    Camera cam;
    Ray ray;
    RaycastHit hit;

    public static int id;

    public Transform player;

    [SerializeField] private int pressRange;

    private void Start()
    {
        cam = Camera.main;
    }
    public UnityEvent OnButtonPressed;
    public void ButtonPress()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if ((Physics.Raycast(ray, out hit, pressRange)))
        {
            OnButtonPressed?.Invoke();
        }
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

