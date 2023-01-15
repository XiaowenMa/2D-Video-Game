using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DarkRoom
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController instance;

        //outlets
        Rigidbody2D _rigidbody2D;
        CapsuleCollider2D cc;
        Vector2 colliderSize;
        public GameObject projectilePrefab;
        public GameObject firePrefab;
        public Transform aimPivot;

        SpriteRenderer sprite;
        Animator animator;

        //state tracking
        public bool isPaused;
        public int jumpsLeft;
        bool faceRight;
        bool isJump;
        // public int score;
        public int torchNum;
        public float timeLeft;

        private float slopeDownAngle;
        private float slopeSideAngle;
        // private float checkDist = 0.5f;
        private Vector2 slopeNormalPerp = new Vector2(1f,1f).normalized;
        private bool isOnSlope;
        private bool isUpwardSlope;

        //configuration
        private Vector3 slopeOffset = new Vector3(0,-0.25f,0);
        // public float healthMax = 100f;
        // public float health = 100f;
        
        // public float damageFromMissile = 5f;

        


        // methods
        void Awake(){
            instance = this;
        }

        void Start()
        {
            sprite = GetComponent<SpriteRenderer>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            cc = GetComponent<CapsuleCollider2D>();
            colliderSize = cc.size;
        }

        void FixedUpdate(){
            //Syncronized with physics engine
            float speed = _rigidbody2D.velocity.magnitude;
            animator.SetFloat("speed",speed);
            animator.SetFloat("timeLeft",timeLeft);
            if(speed > 0){
                animator.speed = speed / 4f;
            }
            else{
                animator.speed = 1f;
            }
        }


        // void TakeDamage(float damageAmount)
        // {
        //     // health -= damageAmount;
        //     // if (health <= 0)
        //     // {
        //     //     Die();
        //     // }
        //     // GameController.instance.timeRemained -= 5f;
        // }

        void Die()
        {
            //restart scene when hp <= 0
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        void Update()
        {
            //if health <= 0, reload game
            // if(health<=0){
            //     Die();
            // }

            //check if the game is paused, if paused, stop player movements
            if(isPaused){
                return;
            }

            //move left
            if (Input.GetKey(KeyCode.A))
            {   //check if the player is in the air(i.e. jump), if so, change the horizontal speed, so it wouldnlt jump too far
                if(isJump){
                    // in the air, slow down the horizontal movement
                    // print("Air");
                    _rigidbody2D.AddForce(Vector2.left * 7f * Time.deltaTime, ForceMode2D.Impulse);
                }
                else if(isOnSlope){//Move along slope
                    if(isUpwardSlope){
                        _rigidbody2D.AddForce(new Vector2(-1,-1).normalized * 15f * Time.deltaTime, ForceMode2D.Impulse);
                    }
                    else{
                        _rigidbody2D.AddForce(new Vector2(-1,1).normalized * 15f * Time.deltaTime, ForceMode2D.Impulse);
                    }
                }
                else{
                    _rigidbody2D.AddForce(Vector2.left * 10f * Time.deltaTime, ForceMode2D.Impulse);
                }

                sprite.flipX = true;
                faceRight = false;
            }

            //move right 
            if (Input.GetKey(KeyCode.D))
            {
                if(isJump){
                    // in the air, slow down the horizontal movement
                    // print("Air");
                    _rigidbody2D.AddForce(Vector2.right * 7f * Time.deltaTime, ForceMode2D.Impulse);
                }
                else if(isOnSlope){//Move along slope
                    if(isUpwardSlope){
                        _rigidbody2D.AddForce(new Vector2(1,1).normalized * 15f * Time.deltaTime, ForceMode2D.Impulse);
                    }
                    else{
                        _rigidbody2D.AddForce(new Vector2(1,-1).normalized * 15f * Time.deltaTime, ForceMode2D.Impulse);
                    }
                }
                else{
                    _rigidbody2D.AddForce(Vector2.right * 10f * Time.deltaTime, ForceMode2D.Impulse);
                }
                sprite.flipX = false;
                faceRight = true;
            }

            //jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (jumpsLeft > 0)
                {
                    jumpsLeft--;
                    _rigidbody2D.AddForce(Vector2.up * 6f, ForceMode2D.Impulse);
                    isJump=true;
                }
            }
            animator.SetInteger("jumpsLeft",jumpsLeft);

            // if (Input.GetKeyDown(KeyCode.Escape))
            // {
            //     MenuController.instance.Show();
            // }

            //Press L to light up the entire map for 2 seconds
            if(Input.GetKeyDown(KeyCode.L)){
                if(torchNum>0){
                    torchNum--;
                    GameController.instance.GlobalLightOn();
                }

            }


            //check the num of usable matches, if >0, the player can fire to light up the lamp(add a condition)
            //Aim Toward Mouse
            Vector3 mousePosition = Input.mousePosition;
            Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 directionFromPlayerToMouse = mousePositionInWorld - transform.position;
            // this transform is the transform of the Player
            
            float radiansToMouse = Mathf.Atan2(directionFromPlayerToMouse.y,directionFromPlayerToMouse.x);
            float angleToMouse = radiansToMouse * Mathf.Rad2Deg;

            aimPivot.rotation = Quaternion.Euler(0,0,angleToMouse);
            //Fire to light up the lamp
            if(Input.GetMouseButtonDown(0)){
                GameObject newProjectile = Instantiate(firePrefab);
                newProjectile.transform.position = transform.position;
                newProjectile.transform.rotation = aimPivot.rotation;
            }

            //Shoot
            if(Input.GetKeyDown(KeyCode.Return)){
                GameObject newProjectile = Instantiate(projectilePrefab);
                newProjectile.transform.position = transform.position;
                if(!faceRight){
                    newProjectile.transform.rotation = Quaternion.Euler(0,0,180);
                }
            }

            SlopeCheck();

        }

        //Slope Movement
        void SlopeCheck(){
            Vector2 checkPos = transform.position - (Vector3)(new Vector2(0.0f,colliderSize.y/2));
            // print("check");

            // SlopeCheckVertical(checkPos);
            // SlopeCheckHorizontal(checkPos);

            if(isOnSlope){
                print("On Slope");
            }
        }


        //double jump
        void OnCollisionStay2D(Collision2D other)
        {
            isJump=false;
            isOnSlope = false;
            //check that we collided with ground
            if (other.gameObject.layer == LayerMask.NameToLayer("Ground") || other.gameObject.layer == LayerMask.NameToLayer("Slope")||other.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                //
                print("hits");
                //check what is directly below our character's feet
                RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, -transform.up, 0.55f);
                // Debug.DrawRay(transform.position, -transform.up*0.7f);//visualize raycast

                //we might have multiple things below our character's feet
                for (int i = 0; i < hits.Length; i++)
                {
                    RaycastHit2D hit = hits[i];
                    //check that we collided with ground right below our feet
                    if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground")||hit.collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
                    {
                        //reset jump count
                        jumpsLeft = 2;
                        print(2);
                    }
                    if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Slope"))
                    {
                        // isOnSlope = true;
                        jumpsLeft = 2;
                        print(1);
                    }
                }

                RaycastHit2D[] hits_back = Physics2D.RaycastAll(transform.position+slopeOffset, -transform.right, 0.5f);
                for (int i = 0; i < hits_back.Length; i++)
                {
                    RaycastHit2D hit = hits_back[i];

                    if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Slope"))
                    {
                        isOnSlope = true;
                        isUpwardSlope=false;//the slope is downward
                        jumpsLeft = 2;
                        print(1);
                    }
                }

                RaycastHit2D[] hits_front = Physics2D.RaycastAll(transform.position+slopeOffset, transform.right, 0.5f);
                for (int i = 0; i < hits_front.Length; i++)
                {
                    RaycastHit2D hit = hits_front[i];

                    if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Slope"))
                    {
                        isOnSlope = true;
                        isUpwardSlope=true;//foward slope
                        jumpsLeft = 2;
                        print(1);
                    }
                }
                // animator.SetInteger("JumpLeft",jumpsLeft);
            }

            

        }

    }
}

