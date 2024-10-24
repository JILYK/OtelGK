using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public Text Text;
    public GameObject LoginManedjer;
    public void VRClick()
    {
        LoginManedjer.GetComponent<LoginConfig>().InputTextGO.text += this.name;
    }
}
