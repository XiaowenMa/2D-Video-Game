using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkRoom{
    public class InformationPopUp : MonoBehaviour
    {
        void OnCollisionEnter2D(Collision2D other){
            if(other.gameObject.GetComponent<PlayerController>()){
                PopUpSystem pop = GameController.instance.GetComponent<PopUpSystem>();
                pop.ShowInfoPopUp();
                GetComponent<Collider2D>().enabled = false;
            }
        }
    }
}

