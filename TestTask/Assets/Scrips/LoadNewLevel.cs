using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scrips
{
    public class LoadNewLevel : MonoBehaviour
    {
        [SerializeField] private string _nextLevel;
        [SerializeField] private float _delay;
        [SerializeField] private AudioClip _winSound;

        private AudioSource _audio;

        private void Awake()
        {
            _audio = GetComponent<AudioSource>();
        }

        public void LoadLevel()
        {
            _audio.PlayOneShot(_winSound);
            Invoke("WaitAndStart", _delay);
        }

        private void WaitAndStart()
        {
            SceneManager.LoadScene(_nextLevel);
        }
    }
}