using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

namespace DarkRoom{
    public class MissileShooter : MonoBehaviour
    {
        //outlet
        public Transform missileSpawnPoint;
        public GameObject leftMissilePrefab;
        public GameObject rightMissilePrefab;
        SpriteRenderer sprite;
        int isLeft;
        
        //state tracking
        public float missileDelay;

        //configuration
        public Vector2 position;
        
        //method
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine("MissileSpawnTimer");
            position = transform.position;
            sprite = GetComponent<SpriteRenderer>();

        }

        void Update(){
            transform.position = new Vector2(position.x,position.y+Mathf.Sin(GameController.instance.timeRemained));

        }

        void spawnMissile()
        {
            if (isLeft == 1)
            {
                sprite.flipX = false;
                GameObject newLeftMissile = Instantiate(leftMissilePrefab, missileSpawnPoint.position, Quaternion.identity);
            }
            else
            {
                sprite.flipX = true;
                GameObject newRightMissile = Instantiate(rightMissilePrefab, missileSpawnPoint.position, Quaternion.identity);
            }
        }

        IEnumerator MissileSpawnTimer()
        {
            //wait
            yield return new WaitForSeconds(missileDelay);
            
            //randomly select a direction and spawn
            // System.Random random = new System.Random();
            // isLeft = random.Next(0,2);
            if(PlayerController.instance.transform.position.x >= transform.position.x){
                isLeft= 0;
            }
            else{
                isLeft = 1;
            }
            spawnMissile();
            
            //repeat
            StartCoroutine("MissileSpawnTimer");
        }


        void OnCollisionEnter2D(Collision2D other){
            if(other.gameObject.GetComponent<PlayerController>()){
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }


    }
}

