using System;
using UnityEngine;

namespace Scrips
{
    public class RotationBlock : MonoBehaviour
    {
        public float speed = 2.5f;
        private Quaternion _start;
        private Quaternion _left = Quaternion.Euler(0, 0, -90);
        private Quaternion _down = Quaternion.Euler(0, 0, 0);

        private Quaternion _end;
        private bool _OnRotate = false;

        private void Start()
        {
            _start = transform.rotation;
            _end = transform.rotation;

        }

        private void Update()
        {
            if (Physics2D.gravity.x < 0)
            {
                _start = transform.rotation;
                _end = _left;
            }
            if (Physics2D.gravity.y < 0)
            {
                _start = transform.rotation;
                _end = _down;
            }

            transform.rotation = Quaternion.Lerp(_start, _end, Time.time * speed);
            
        }
    }
}