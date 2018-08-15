using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace VRTK {


    public class OpenDoorScript1 : VRTK_InteractableObject {

        
        public override void StartUsing(VRTK_InteractUse currentUsingObject)
        {
            base.StartUsing(currentUsingObject);
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
            if (tag == ("Tavern"))
            {
                Tavern();
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
        void Tavern()
        {
            SceneManager.LoadScene("TavernBarScene");
        }

    }

}
