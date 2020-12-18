using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Framework;

namespace HTLibrary.Utility
{
    public class BulletFly : MonoBehaviour
    {
        private Rigidbody _rigidBody;

        public float Speed;

        public float Acceleration;

        Vector3 _movement;

        public float startTime = 0.2f;
        private float timer;

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        void Movement()
        {
            _movement =transform.forward* (Speed / 10) * Time.deltaTime;

            //transform.Translate(_movement,Space.World);
            if (_rigidBody != null)
            {
                _rigidBody.MovePosition(this.transform.position + _movement);
            }
         
            // We apply the acceleration to increase the speed
            Speed += Acceleration * Time.deltaTime;
        }

        private void FixedUpdate()
        {
           
            if(timer>startTime)
            {
                Movement();
            }
            else
            {
                timer += Time.deltaTime;
            }

        }

        private void OnDisable()
        {
            timer = 0;
        }
    }

}
