using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DarkRoom{
    public class Swamp : MonoBehaviour
    {
        //Reset Scene if the other object is player
        void OnTriggerEnter2D(Collider2D other){
            // print("collide");
            if(other.gameObject.GetComponent<PlayerController>()){
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }
}

