using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace VRTK {


    public class OpenDoorScript : VRTK_InteractableObject
    {

        public override void StartUsing(VRTK_InteractUse currentUsingObject = null)
        {
            base.StartUsing(currentUsingObject);
            //Change this to the scene that the door will load
            //SceneManager.LoadScene(1);
            //Debug.Log("ThisIsWorking");
            if (tag == ("KnightDoor"))
            {
                Knight();
            }
            if (tag == ("MageDoor"))
            {
                Mage();
            }
            if (tag == ("Exit"))
            {
                Quit();
            }

        }

        void Quit()
        {
            Application.Quit();
        }

        void Mage()
        {
            SceneManager.LoadScene("MageRoom");
        }

        void Knight()
        {
            SceneManager.LoadScene("TestKnights");
        }

    }
}

