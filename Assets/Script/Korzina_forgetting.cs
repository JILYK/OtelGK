using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using Valve.VR.InteractionSystem;

public class Korzina_forgetting : MonoBehaviour
{
    private bool in_troger = false;
    public int chet_object_in_korzina = 0;
    public General counter;
    Throwable arr_Throwable;
    Rigidbody arr_Rigidbody;
    public GameObject TRIGER_object;
    public Text textNum;
    private List<Vector3> list_positon = new List<Vector3>() {
            new Vector3((float)7.305, (float)6.492, (float)5.759),
            new Vector3((float)5.341806, (float)7.457521, (float)5.522926),
            new Vector3((float)8.341806, (float)7.457521, (float)5.522926),                                              
            new Vector3((float)7.341806, (float)7.457521, (float)5.522926)};

    private void Start()
    {
        counter = GetComponent<General>();
    }
    private void OnTriggerExit(Collider other)
    {
        print("in_troger = false");
        TRIGER_object = null;
        in_troger = false; //не даём при выгоде из тригера положить в корзину
    }
    private void OnTriggerEnter(Collider other)
    {
        print("in_troger = true");
        TRIGER_object = other.gameObject;
        in_troger = true; //разрешаем ложить в корзину


    }
    public void VR_triger_object_forgetting() //при отпускании предмета ложиться по своей позиции и теряет свойства взаимодействия
    {
        print("я начал работу");
        if (in_troger)
        {
            print("in triger true");
            if (TRIGER_object.gameObject.tag == "forgetting") //принимает только определённый тип обьектов
            {
                if (chet_object_in_korzina < 1) //счётчик
                {
                    print("Чото положили");
                    counter.garbage_object++; //увеличиваем значение переменной в файле General
                    chet_object_in_korzina++;
                    textNum.text = counter.garbage_object.ToString();
                }
                arr_Throwable = TRIGER_object.GetComponent<Throwable>();
                Interactable arr_Interactable = TRIGER_object.GetComponent<Interactable>();
                arr_Interactable.OnDetachedFromHand(arr_Interactable.hoveringHand);
                arr_Rigidbody = TRIGER_object.GetComponent<Rigidbody>();
                print(TRIGER_object.transform.parent);
                TRIGER_object.transform.SetParent(this.transform.parent);
                arr_Throwable.attachmentFlags = 0;
                arr_Rigidbody.isKinematic = true;
                arr_Rigidbody.detectCollisions = false;
                TRIGER_object.GetComponent<Throwable>().Equals(arr_Throwable);




                TRIGER_object.transform.position = list_positon[0];
                if (TRIGER_object.transform.position == list_positon[0]) chet_object_in_korzina = 0;
                list_positon.RemoveAt(0);


            }
        }
    }


}
