using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeOpener : MonoBehaviour, IInteractable
{
    public GameObject ui;
    public Transform player;

    public void Interact()
    {
        ui.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
