using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.Extras;

public class LaserInputKey : SteamVR_LaserPointer
{
    public GameObject LoginManadjer;
    public override  void OnPointerIn(PointerEventArgs e)
    {
        base.OnPointerIn(e);
        if (e.target.CompareTag("KeyBoard"))
        {
            e.target.GetComponent<Image>().color = Color.red;
        }
    }

    public override  void OnPointerClick(PointerEventArgs e)
    {
        base.OnPointerIn(e);
        if (e.target.CompareTag("KeyBoard"))
        {
            e.target.GetComponent<Image>().color = Color.blue;
            e.target.GetComponent<ButtonClick>().VRClick();
        }    

        if (e.target.CompareTag("LoginUI"))
        {
            LoginManadjer.GetComponent<LoginConfig>().InpytTypeValue("LoginUI");
        }       
        if (e.target.CompareTag("PasswordUI"))
        {
            LoginManadjer.GetComponent<LoginConfig>().InpytTypeValue("PasswordUI");
        }
        
    }

    public override  void OnPointerOut(PointerEventArgs e)
    {
        base.OnPointerIn(e);
        if (e.target.CompareTag("KeyBoard"))
        {
            e.target.GetComponent<Image>().color = Color.black;
        }
    }
}
