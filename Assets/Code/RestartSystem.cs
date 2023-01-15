using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace DarkRoom{
    public class RestartSystem : MonoBehaviour
    {
        public GameObject popUpBox;
        public TMP_Text popUpText;
        public Animator animator;

        public void PopUp(string text){
            // print("POP UP");
            popUpBox.SetActive(true);
            popUpText.text = text;
            animator.SetTrigger("popUp");

            //pause the game
            PlayerController.instance.isPaused = true;
            Invoke("ToggleTimeScale",0.5f);
        }

        void ToggleTimeScale(){
            if(PlayerController.instance.isPaused){
                Time.timeScale = 0;
            }
            else{
                Time.timeScale = 1;
            }
        }

        public void ResumeGame(){
            if(PlayerController.instance != null){
                PlayerController.instance.isPaused=false;
                ToggleTimeScale();
            }
            
        }

        public void RestartGame(){
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}

