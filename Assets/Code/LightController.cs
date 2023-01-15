using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkRoom{
    public class LightController : MonoBehaviour
    {
        // UnityEngine.Rendering.Universal.Light2D
        public GameObject lamp;
        public Animator animator;

        public void LightUp(){

            animator.SetTrigger("lightOn");
        }

        void OnCollisionEnter2D(Collision2D other){
            if(other.gameObject.GetComponent<FireProjectile>()){//add match num check later
                LightUp();
                Invoke("LightDown",4f);
            }
        }

        void LightDown(){
            animator.SetTrigger("lightOff");
        }
    }
}

