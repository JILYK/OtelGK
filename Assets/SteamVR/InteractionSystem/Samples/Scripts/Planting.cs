//======= Copyright (c) Valve Corporation, All rights reserved. ===============

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

namespace Valve.VR.InteractionSystem.Sample
{
    public class Planting : MonoBehaviour
    {
        public SteamVR_Action_Boolean plantAction;

        public Hand hand;
        
        public GameObject prefabToPlant;

        //---------------------------------------//
        public GameObject UI_butX;
        private int UI_boolX = 1;
        //---------------------------------------//


        private void OnEnable()
        {
            if (hand == null)
                hand = this.GetComponent<Hand>();

            if (plantAction == null)
            {
                Debug.LogError("<b>[SteamVR Interaction]</b> No plant action assigned", this);
                return;
            }

        }

        private void OnDisable()
        {
            if (plantAction != null)
                plantAction.RemoveOnChangeListener(OnPlantActionChange, hand.handType);
        }

        private void OnPlantActionChange(SteamVR_Action_Boolean actionIn, SteamVR_Input_Sources inputSource, bool newValue)
        {
                
            if (newValue)
            {
                Plant();
            }
        }

        public void Plant()
        {
            
            if (UI_boolX > 0)
            {
                UI_butX.SetActive(true);
                UI_boolX = UI_boolX * -1;
            }
            else
            {
                UI_butX.SetActive(false);
                UI_boolX = UI_boolX * -1;
            }
        }

        
        private void Update()
        {

        }
    }
  
}