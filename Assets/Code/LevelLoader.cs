using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

namespace DarkRoom{
    public class LevelLoader : MonoBehaviour
    {
        public Animator transition;
        public static LevelLoader instance; 

        public float transitionTime = 1f;

        void Awake()
        {
            instance = this; 
        }
        // Update is called once per frame
        

        public void LoadNextLevel()
        {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1)); 
        }

        IEnumerator LoadLevel(int levelIndex)
        {
            transition.SetTrigger("Start");
            yield return new WaitForSeconds(transitionTime);
            SceneManager.LoadScene(levelIndex);
        }
        
        
    }
}

