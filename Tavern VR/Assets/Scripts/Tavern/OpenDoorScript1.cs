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
            if (tag == ("Gary"))
            {
                Gary();
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
        void Gary()
        {
            Debug.Log("Restart");
            int current = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(current, LoadSceneMode.Single);

        }

    }

}
