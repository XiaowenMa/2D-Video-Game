using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkRoom{
    public class rightMissile : MonoBehaviour
    {
        //outlets
        Rigidbody2D _rigidbody;
        public float missileSpeed;
        
        
        //state tracking


        // Start is called before the first frame update
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            
        }

        // Update is called once per frame
        void Update()
        {
            _rigidbody.velocity = Vector2.right * missileSpeed;
            
        }

        void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
        
        void OnCollisionEnter2D(Collision2D other)
        {
            Destroy(gameObject);
            if(other.gameObject.GetComponent<PlayerController>()){
                GameController.instance.timeRemained-=5f;
            }
        }
    }
}

