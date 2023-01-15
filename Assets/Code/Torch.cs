using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkRoom{
    public class Torch : MonoBehaviour
    {
        //Outlets
        UnityEngine.Rendering.Universal.Light2D _light;

        // Start is called before the first frame update
        void Start()
        {
            _light = gameObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        }

        void OnCollisionEnter2D(Collision2D other){
            if(other.gameObject.GetComponent<Projectile>()){
                LightUp();      
            }
        }

        void LightUp(){
            _light.intensity = 0.5f;
            _light.pointLightOuterRadius += (float)2;
            _light.GetComponent<Collider2D>().enabled = false;
            Invoke("LightDown", 1.0f);
        }

        void LightDown(){
            _light.pointLightOuterRadius -= (float)2;
            _light.intensity = 0.25f;
        }
    }
}

