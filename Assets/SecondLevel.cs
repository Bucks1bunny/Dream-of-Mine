using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondLevel : MonoBehaviour
{
    public List<ButtonOrder> buttons;

    public Transform player;
    private float rangeToButton = 2f;
    private Vector3 distanceToPlayer;
    private void Start()
    {
        distanceToPlayer = player.position - buttons[].transform.position;
    }
    void Update()
    {
        if (distanceToPlayer.magnitude <= rangeToButton && Input.GetKeyDown(KeyCode.E))
        {
            if()
        }
    }
    private void ButtonPressed(ButtonOrder button)
    {

    }
}
