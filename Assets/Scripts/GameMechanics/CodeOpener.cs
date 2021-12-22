using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeOpener : Interactable
{
    public GameObject ui;
    public Transform player;
    /*
    public override string ShowHand()
    {
        return "Press [<color=red>E</color>] to open keyCode.";
    }
    */
    public override void Interact()
    {
        ui.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
