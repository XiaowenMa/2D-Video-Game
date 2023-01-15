using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkRoom{
    public class ClimbingMovement : MonoBehaviour
    {
        private float vertical;
        private float speed = 2f;
        private bool isClimbbing;
        private bool climb;
        private bool onLadder;
        // private int index = -1;

        Animator playerAnimator;
        Rigidbody2D _rigidbody2D;

        // //version2
        // private float dist=0.15f;
        // private float inputHorizontal;
        // private float inputVertical;

        void Start(){
            playerAnimator = GetComponent<Animator>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            vertical = Input.GetAxis("Vertical");

            if (climb && Mathf.Abs(vertical)>0f){
                isClimbbing = true;
            }
            else{
                isClimbbing = false;
            }

            // //Version 2
            // inputHorizontal = Input.GetAxisRaw("Horizontal");

            // RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position,transform.up,dist);
            // index = -1;
            // for (int i = 0; i < hits.Length; i++)
            // {
            //     RaycastHit2D hit = hits[i];
            //     //check that we collided with ground right below our feet
            //     if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ladder"))
            //     {
            //         print("Hit Ladder");
            //         index = i;
            //     }
            // }
            // if(Input.GetKeyDown(KeyCode.UpArrow)){
            //     isClimbbing = true;
            // }
            // else if(Input.GetKeyDown(KeyCode.A) ||Input.GetKeyDown(KeyCode.D)){
            //     isClimbbing = false;
                
            // }
        }

        //
        private void FixedUpdate(){
            if(climb){
                _rigidbody2D.gravityScale = 0f;
                if(isClimbbing){
                    playerAnimator.SetBool("isClimb",true);
                    _rigidbody2D.velocity = new Vector2(0, vertical * speed);
                }
                // else{//stand on ladder but not pushing up/down
                //     _rigidbody2D.gravityScale = 1f;
                //     // _rigidbody2D.velocity = new Vector2(0, 0);
                // }
            }

            else{
                _rigidbody2D.gravityScale = 1f;
                // _rigidbody2D.velocity = new Vector2(0.0f,0.0f);
            }


            // //Version 2
            // if(isClimbbing && index != -1){
            //     vertical = Input.GetAxis("Vertical");
            //     _rigidbody2D.velocity = new Vector2(0, vertical * speed);
            //     _rigidbody2D.gravityScale = 0;
            //     playerAnimator.SetBool("isClimb",true);
            // }
            // else if(index != -1){//still on ladder, but choose to move aside
            //     _rigidbody2D.gravityScale = 0;
            //     playerAnimator.SetBool("isClimb",false);
            // }
            // else{
            //     _rigidbody2D.gravityScale = 1f;
            //     playerAnimator.SetBool("isClimb",false);
            // }
            


        }
        
        private void OnTriggerEnter2D(Collider2D other){
            
            if(other.gameObject.layer == LayerMask.NameToLayer("Ladder")){
                climb = true;
                // _rigidbody2D.gravityScale = 0f;
            }
        }

        private void OnTriggerExit2D(Collider2D other){
            if(other.gameObject.layer == LayerMask.NameToLayer("Ladder")){
                isClimbbing = false;
                climb = false;
                playerAnimator.SetBool("isClimb",false);
            }
        }
    }
}

