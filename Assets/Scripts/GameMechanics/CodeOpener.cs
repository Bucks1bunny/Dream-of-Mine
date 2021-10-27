using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeOpener : MonoBehaviour
{
    public GameObject ui;
    public Transform player;

    private float pressRange = 2f;
    private void OnMouseDown()
    {
        Vector3 distanceToPlayer = player.position - transform.position;

        if (distanceToPlayer.magnitude <= pressRange)
        {
            Time.timeScale = 0;
            ui.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
