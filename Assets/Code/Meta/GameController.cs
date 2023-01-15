using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


namespace DarkRoom{
    public class GameController : MonoBehaviour
    {
        public static GameController instance;

        //Outlets
        public TMP_Text timeText;
        public PlayerController player;
        public TMP_Text scoreUI;
        public TMP_Text torchNumUI;


        public UnityEngine.Rendering.Universal.Light2D globalLight;

        //State Tracking
        public float timeRemained;
        bool lose;

        // private int score;
        private int torchNum;
        // private float health;
        
        void Awake(){
            instance = this;
        }

        void Update(){
            if(timeRemained>0){
                timeRemained -= Time.deltaTime;
                PlayerController.instance.timeLeft = timeRemained;
                // print(timeRemained);
                timeText.text = Mathf.Floor(timeRemained).ToString();
            }
            if(timeRemained<=0 && !lose){
                timeText.text = "0";
                lose = true;
                PopUpSystem pop = instance.GetComponent<PopUpSystem>();//Pop up a new window to restart
                pop.ShowGameOverPopUp();
            }

            //make score and torch number 
            // score = player.score;
            torchNum = player.torchNum;
            // health = player.health;
            
            UpdateDisplay();
        }

        public void RestartGame(){
            print(SceneManager.GetActiveScene().name);
            Time.timeScale=1;//Reset the time scale so it can reload!
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        void UpdateDisplay()
        {
            //update UI
            // scoreUI.text = score.ToString();
            torchNumUI.text = torchNum.ToString();
        }

        public void GlobalLightOn(){
            globalLight.intensity = 0.25f;
            Invoke("GlobalLightDown",2f);
        }

        public void GlobalLightDown(){
            globalLight.intensity = 0f;
        }

        public void LoadLevel(int index){
            Time.timeScale = 1;
            SceneManager.LoadScene(index);
        }


    }
}
