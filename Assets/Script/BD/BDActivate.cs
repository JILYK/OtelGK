using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BDActivate : MonoBehaviour
{
    public GameObject BoxF;
    public GameObject BoxG;
    void Start()
    {
        Config.BoxForgeting = BoxF;
        Config.BoxGarbage = BoxG;

        BDConnect.PuskConect();
    }


}
