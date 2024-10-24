using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Controller : MonoBehaviour
{
    private SteamVR_Action_Boolean Close_UI_X;
    private SteamVR_Action_Boolean Next_UI_Y;
    private SteamVR_Behaviour_Pose m_pose;




    //[Tooltip("Hand collider prefab to instantiate")]
    //public HandCollider handColliderPrefab;
    //[HideInInspector]
    //public HandCollider handCollider;
    ////////////////////////////////////////////////
    public GameObject UI_Start;
    public GameObject UI_Hand;

    private bool on_off_UI;

    public Text lesson_text;
    public Text object_in_hand_text;
    public GameObject TRIGER_object;

    public GameObject test_collider;



    //  private Hand hand;
    //private GameObject grabbedObject;

    //private void OnCollisionEnter(Collision collision)
    //{
    //    print("Collision detected");
    //}
    private void Awake()
    {
        Close_UI_X = SteamVR_Actions._default.X_button;
        Next_UI_Y = SteamVR_Actions._default.Y_button;
        m_pose = GetComponent<SteamVR_Behaviour_Pose>();
        on_off_UI = true;
       // hand = GetComponent<Hand>();
        UI_Hand.SetActive(false);

    }
    // Start is called before the first frame update
    void Start()
    {
      //  handCollider = ((GameObject)Instantiate(handColliderPrefab.gameObject)).GetComponent<HandCollider>();

    }

    // Update is called once per frame
    void Update()
    {
      //.  handCollider.SetCollisionDetectionEnabled(collisionsEnabled);
        ////////////////////////////////////////////////
        if (Close_UI_X.GetStateDown(m_pose.inputSource))
        {
            if (UI_Start.activeSelf) UI_Start.SetActive(false);
            if (UI_Hand.activeSelf) UI_Hand.SetActive(false);
            on_off_UI = !on_off_UI;
            
        }

        if (Next_UI_Y.GetStateDown(m_pose.inputSource))
        {
            if (UI_Start.activeSelf) lesson_text.text = "Для начала мы может предложить Вам ознакомиться с механикой мытья полов и сбора предметов.                   Для закрытия этого окна нажмите Х";
        }

        /////////////////////////////////////////////////////////
        //if (Close_UI_X.GetStateDown(m_pose.inputSource))
        //{
        //    if (UI_Hand.activeSelf) UI_Hand.SetActive(false);

        //    else UI_Hand.SetActive(true);
        //}
    }
    public void UI_menu_off()
    {
        TRIGER_object = null;
        UI_Hand.SetActive(false);


    }
    public void UI_menu_on(string tag)
    {
        //TRIGER_object = other.gameObject;
        if (on_off_UI)
        {
            UI_Hand.SetActive(true);
            object_in_hand_text.text = "Это";
            if (tag == "forgetting")
            {
                object_in_hand_text.text += " потярянный предмет. Его необходимо положить в соответствующую корзину";
            }
            else if (tag == "garbage")
            {
                object_in_hand_text.text += " мусор. Его необходимо положить в соответствующую корзину";
            }
            else if (tag == "mop_carcas")
            {
                object_in_hand_text.text += " швабра, ей моют пол :)";
            }
        }
    }
}
