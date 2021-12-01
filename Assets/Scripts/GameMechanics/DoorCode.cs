using TMPro;
using System.Collections;
using UnityEngine;

public class DoorCode : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textCode;
    private string code;
    private string rightCode = "4756";
    public GameObject ui;
    public GameObject door;
    private void Start()
    {
        code = string.Empty;
        textCode.text = code;
    }
    #region Buttons
    public void Button_1() { textCode.text += "1"; }
    public void Button_2() { textCode.text += "2"; }
    public void Button_3() { textCode.text += "3"; }
    public void Button_4() { textCode.text += "4"; }
    public void Button_5() { textCode.text += "5"; }
    public void Button_6() { textCode.text += "6"; }
    public void Button_7() { textCode.text += "7"; }
    public void Button_8() { textCode.text += "8"; }
    public void Button_9() { textCode.text += "9"; }
    #endregion
    public void Button_Back() 
    {
        Time.timeScale = 1;
        ui.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Button_Reset() { textCode.text = string.Empty; }
    public void Button_Submit()
    {
        if (textCode.text.Equals(rightCode))
        {
            Button_Back();
            Destroy(door);
        }
        else
        {
            StartCoroutine(ErrorPopup());
        }
    }
    IEnumerator ErrorPopup()
    {
        textCode.text = "ERROR";
        yield return new WaitForSecondsRealtime(.5f);
        Button_Reset();
        yield return new WaitForSecondsRealtime(.3f);
        textCode.text = "ERROR";
        yield return new WaitForSecondsRealtime(.5f);
        Button_Reset();
        yield return new WaitForSecondsRealtime(.3f);
        textCode.text = "ERROR";
        yield return new WaitForSecondsRealtime(.5f);
        Button_Reset();
    }
}
