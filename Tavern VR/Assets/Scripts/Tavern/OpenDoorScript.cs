﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace VRTK {


    public class OpenDoorScript : VRTK_InteractableObject {

        
        public override void StartUsing(VRTK_InteractUse currentUsingObject = null)
        {
            base.StartUsing(currentUsingObject);
            //Change this to the scene that the door will load
            SceneManager.LoadScene(1);  
            //Debug.Log("ThisIsWorking");

        }
    }

    
}