using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRTK
{
    public class RenderElementSpell : MonoBehaviour
    {
        enum MySpellType { bolt, shield };
        MySpellType thisSpell;
        SpellScript mySpell;
        bool hasElement = false;

        public int myElement;
        public GameObject[] myRenderElements;
        //MAKE SURE THESE ARE IN THE SAME ORDER AS THE myElement Int list
        //0 = Fire, 1 = Thorns, 2 = Water.

        private void Start()
        {
            if (GetComponentInParent<SpellScript>() != null)
            {
                mySpell = GetComponentInParent<SpellScript>();
            }

            ChangeElement();
        }

        private void Update()
        {
            //myElement = mySpell.elementType;
            //if this spell is a bolt
            if (myElement != mySpell.elementType)
            {
                //and if it's element is not the bolt's element
                myElement = mySpell.elementType;
                //set this object's element to it's bolt's element
                ChangeElement();
                //and changeelement
            }
        }

        private void ChangeElement()
        {
            //changes element to the chosen element, disables all elements that aren't the bolt's element
            for (int i = 0; i < myRenderElements.Length; i++)
            {
                //for each of the spell renders under this,
                if (i != myElement)
                {
                    myRenderElements[i].SetActive(false);
                    //if the number representing the element is not my element, set it to false
                }
                else
                {
                    myRenderElements[i].SetActive(true);
                    //else set to true
                }
            }
        }
    }
}
