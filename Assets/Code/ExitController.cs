using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkRoom
{
    public class ExitController : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerController>())
            {
                LevelLoader.instance.LoadNextLevel();
            }
            
        }
    }
}

