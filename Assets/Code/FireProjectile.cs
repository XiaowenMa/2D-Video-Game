using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkRoom{
    public class FireProjectile : MonoBehaviour
    {
        //Outlets
        Rigidbody2D _rigidbody2D;

        // Methods
        void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.velocity = transform.right * 10f;
        }

        void OnCollisionEnter2D(Collision2D collision){
            Destroy(gameObject);
        }
    
    }
}

