using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkRoom{
    public class Wall : MonoBehaviour
    {
        // Method
        void OnCollisionEnter2D(Collision2D other){
            if(other.gameObject.GetComponent<Projectile>()){
                // print("ccccc");
                Destroy(gameObject);
            }
        }
    }
}

