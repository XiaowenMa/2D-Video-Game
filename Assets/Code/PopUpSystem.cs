using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DarkRoom{
    public class PopUpSystem : MonoBehaviour
    {
        public static PopUpSystem instance;

        public GameObject popUpBox;//Main Menu PopUp Box
        public TMP_Text popUpText;
        public Animator animator;
        public Animator infoAnimator;
        public Animator gameOverAnimator;

        public GameObject levelPopUpBox;
        public GameObject helpPopUpBox;
        public GameObject aboutPopUpBox;
        public GameObject infoBox;
        public GameObject gameOverBox;

        void Awake(){
            instance = this;
            //hide all the popup box(except main menu since it has animation)
            levelPopUpBox.SetActive(false);
            helpPopUpBox.SetActive(false);
            aboutPopUpBox.SetActive(false);
            infoBox.SetActive(false);
            gameOverBox.SetActive(false);
        }

        public void PopUp(string text){//Equals Show(mainMenu) in Q7
            Time.timeScale=1;
            print("POP UP");
            //Set other popup box to false
            levelPopUpBox.SetActive(false);
            helpPopUpBox.SetActive(false);
            aboutPopUpBox.SetActive(false);
            gameOverBox.SetActive(false);

            PlayerController.instance.isPaused=true;
            Invoke("ToggleTimeScale",0.5f);
            
            popUpBox.SetActive(true);
            // popUpText.text = text;
            animator.SetTrigger("pop");

        
        }

        void ToggleTimeScale(){
            if(PlayerController.instance.isPaused){
                Time.timeScale = 0;
            }
            else{
                Time.timeScale = 1;
            }
        }

        public void ShowHelpPopUp(){
            // PopUp("W A S D to Move\nSpace to Jump\nReturn to Break Wall");
            helpPopUpBox.SetActive(true);
            
            //turn off other popupbox
            popUpBox.SetActive(false);
            levelPopUpBox.SetActive(false);
            aboutPopUpBox.SetActive(false);
            gameOverBox.SetActive(false);

            //pause the game
            PlayerController.instance.isPaused=true;
            ToggleTimeScale();
        }

        public void ShowLevelPopUp(){
            levelPopUpBox.SetActive(true);
            
            //turn off other popupbox
            popUpBox.SetActive(false);
            helpPopUpBox.SetActive(false);
            aboutPopUpBox.SetActive(false);
            gameOverBox.SetActive(false);

            //pause the game
            PlayerController.instance.isPaused=true;
            ToggleTimeScale();

        }
        
        public void ShowAboutPopUp(){
            aboutPopUpBox.SetActive(true);
            //turn off other popupbox
            popUpBox.SetActive(false);
            levelPopUpBox.SetActive(false);
            helpPopUpBox.SetActive(false);
            gameOverBox.SetActive(false);

            //pause the game
            PlayerController.instance.isPaused=true;
            ToggleTimeScale();
        }

        public void ShowInfoPopUp(){
            aboutPopUpBox.SetActive(false);
            popUpBox.SetActive(false);
            levelPopUpBox.SetActive(false);
            helpPopUpBox.SetActive(false);
            gameOverBox.SetActive(false);

            infoBox.SetActive(true);
            infoAnimator.SetTrigger("pop");
            PlayerController.instance.isPaused=true;
            Invoke("ToggleTimeScale",0.5f);
        }

        public void ShowGameOverPopUp(){
            aboutPopUpBox.SetActive(false);
            popUpBox.SetActive(false);
            levelPopUpBox.SetActive(false);
            helpPopUpBox.SetActive(false);
            infoBox.SetActive(false);

            gameOverBox.SetActive(true);
            gameOverAnimator.SetTrigger("pop");
            PlayerController.instance.isPaused=true;
            Invoke("ToggleTimeScale",0.5f);
        }

        public void ResumeGame(){
            //turn off all the menu
            aboutPopUpBox.SetActive(false);
            popUpBox.SetActive(false);
            levelPopUpBox.SetActive(false);
            helpPopUpBox.SetActive(false);
            infoBox.SetActive(false);
            gameOverBox.SetActive(false);

            if(PlayerController.instance!=null){
                PlayerController.instance.isPaused=false;
            }
            ToggleTimeScale();
  
        }
    }
}

