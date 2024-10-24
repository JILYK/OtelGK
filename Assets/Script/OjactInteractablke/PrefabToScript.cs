using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabToScript : MonoBehaviour
{
public void BoxActivate()
    {
        print("OWEFLEFGVBEBFJBLEFWEFIBLEWFEWFB LEKJFBFG#L:BFVLJIBEVB OLVBFLOIBGVEVLBOLIWEFVBIBV:PBEDVP:BEWFGVBLi");
        if(this.tag == "forgetting") Config.BoxForgeting.GetComponent<Korzina_forgetting>().VR_triger_object_forgetting();
        if(this.tag == "garbage") Config.BoxGarbage.GetComponent<Korzina_garbage>().VR_triger_object_garbage();
    }
}
