using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class UI_target : MonoBehaviour
{
    public GameObject target;
    public float speed = 2f;
    private Vector3 script_target;
    //////////////////////////////////////////->Hand
    public GameObject UI;
    void Start()
    {
        //поворачивает все дочерние обьектына 180 градусов для правильного отображения
        var children = GetComponentsInChildren<Transform>();
        foreach (var child in children)
        {
            child.gameObject.transform.Rotate(0, 180, 0);
        }

    }

void Update()
    {
        script_target = Vector3.Lerp(script_target, target.transform.position, Time.deltaTime * speed);
        this.transform.LookAt(script_target);
        
    }
}
