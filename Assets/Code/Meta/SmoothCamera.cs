using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkRoom{
    public class SmoothCamera : MonoBehaviour
    {
        public float dampTime = 0.15f;
        private Vector3 velocity = Vector3.zero;
        public Transform target;
        public Transform exit;
        // public Vector3 offset;

        public static SmoothCamera instance;

        //state tracking
        public bool zoomOut;

        void Awake()
        {
            instance = this;
        }
        // void Start(){
        //     offset = transform.position - target.position;
        // }

        // Update is called once per frame
        void Update () 
        {
            if (!zoomOut && target)
            {
                Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
                Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
                Vector3 destination = transform.position + delta;
                // Vector3 destination = target.position + offset;
                transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
            }

            if(zoomOut){

                //Move Camera to Exit then back
                Vector3 point = GetComponent<Camera>().WorldToViewportPoint(exit.position);
                Vector3 delta = exit.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
                // Vector3 delta2 = exit.position - target.position;
                Vector3 destination = transform.position + delta;
                // Vector3 destination = exit.position + offset;
                transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, 0.5f);
                
                Invoke("ZoomBack", 2.0f);
            }

        }

        void ZoomBack(){
            zoomOut = false;
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
            Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            // Vector3 delta3 = target.position - exit.position;
            Vector3 destination = transform.position + delta;

            // Vector3 destination = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, 1f);
        }
    }
}

