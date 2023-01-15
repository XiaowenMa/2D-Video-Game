using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkRoom{
    public class Switch : MonoBehaviour
    {
        //Outlets
        public Animator animator;
        public GameObject exit;

        void OnCollisionEnter2D(Collision2D other){
            if(other.gameObject.GetComponent<PlayerController>()){
                // print("ccccc");
                exit.SetActive(true);
                animator.SetTrigger("show");
                SmoothCamera.instance.zoomOut = true;

                //disable the collider after player touches it
                // GetComponent<Collider2D>().enabled = false;
                Destroy(gameObject);
            }
        }

    }
}

