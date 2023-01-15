using System;
using System.Collections;
using System.Collections.Generic;
using DarkRoom;
using UnityEngine;

namespace DarkRoom{
    public class LitTorch : MonoBehaviour
    {
        //outlet
        Rigidbody2D _rigidbody;
        
        // Start is called before the first frame update
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerController>())
            {
                // PlayerController.instance.score++;
                PlayerController.instance.torchNum++;
                print("Collect");
                Destroy(gameObject);
            }
        }
    }
}

