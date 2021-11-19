using UnityEngine;
using UnityEngine.Events;

public class ButtonTriggerArea : MonoBehaviour
{
    public GameObject[] buttons;

    public int id;
    public static bool onTriggerStay = false;

    public UnityEvent OnButtonCheck;
    private void OnTriggerEnter(Collider other)
    {
        onTriggerStay = true;
        ButtonOrder.GetID(id);

        //Check child gameobjects and turn off all except one
        for (int i = 0; i < buttons.Length; i++)
        {
            Transform child = buttons[i].transform.GetChild(0);
            if (i != id) child.gameObject.SetActive(false);
            else child.gameObject.SetActive(true);
        }
    }
        
    private void OnTriggerExit(Collider other)
    {
        onTriggerStay = false;

        //Check child gameobjects and turn on all 
        for (int i = 0; i < buttons.Length; i++)
        {
            Transform child = buttons[i].transform.GetChild(0);
            child.gameObject.SetActive(true);
        }
    }
    private void Update()
    {
        if (onTriggerStay && Input.GetKeyDown(KeyCode.E))
        {
            OnButtonCheck.Invoke();
        }
    }
}
