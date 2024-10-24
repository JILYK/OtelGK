using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginConfig : MonoBehaviour
{
    public Text LoginTextGO;
    public Text PasswordTextGO;

    public Text InputTextGO;

    public GameObject LoginButton;


    public void InpytTypeValue(string TypeUITag)
    {
        
        if(TypeUITag == "LoginUI") InputTextGO = LoginTextGO;
        else if(TypeUITag == "PasswordUI") InputTextGO = PasswordTextGO;
    }
    public void LoginClick()
    {
        print(LoginTextGO.text + " " + PasswordTextGO.text);
    }

}
