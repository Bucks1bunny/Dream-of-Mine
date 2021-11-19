using System;
using System.Collections.Generic;
using UnityEngine;

public class SecondLevel : MonoBehaviour
{
    public GameObject door;

    private int id;
    private bool isAllButtonsActivated = false;

    [SerializeField] private bool[] buttons = new bool[4];
    private void Update()
    {
        int n = 0;
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i])
                n++;
            if (n == 4)
                SecondLevelCleared();
        }
    }
    public void ButtonPressed()
    {
        id = ButtonOrder.SetID();
        //Check if buttons are activated
        switch (id)
        {
            case 0: 
                Debug.Log($"Button: {id} activated");
                buttons[id] = true; 
                    break;
            case 1:
                if (buttons[0] == false)
                {
                    Debug.Log($"ID: {id}\nButton 1 is not activated, reseting all buttons");
                    for (int i = 0; i < buttons.Length; i++)
                    {
                        buttons[i] = false;
                    }
                }
                else
                {
                    Debug.Log($"Button: {id} activated");
                    buttons[id] = true;
                }
                    break;
            case 2:
                if (buttons[0] == false || buttons[1] == false)
                {
                    Debug.Log($"ID: {id}\nButton 1 and 2 are not activated, reseting all buttons");
                    for (int i = 0; i < buttons.Length; i++)
                    {
                        buttons[i] = false;
                    }
                }
                else
                {
                    Debug.Log($"Button: {id} activated");
                    buttons[id] = true;
                }
                break;
            case 3:
                if (buttons[0] == false || buttons[1] == false || buttons[2] == false)
                {
                    Debug.Log($"ID: {id}\nButton 1, 2 and 3 are not activated, reseting all buttons");
                    for (int i = 0; i < buttons.Length; i++)
                    {
                        buttons[i] = false;
                    }
                }
                else
                {
                    Debug.Log($"Button: {id} activated");
                    buttons[id] = true;
                }
                break;
        }
    }
    private void SecondLevelCleared()
    {
        isAllButtonsActivated = true;
        Destroy(door);
    }
}
