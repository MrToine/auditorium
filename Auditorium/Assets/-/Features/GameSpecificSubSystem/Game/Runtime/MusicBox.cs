using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Runtime
{
    public class MusicBox : MonoBehaviour
    {


        #region Publics

        //
    
        #endregion


        #region Unity API

        private void Start()
        {
            _timer = _intervalBetweenSquares;
            _currentIndex = 0;
            for (int i = 0; i < _squares.Count; i++)
            {
                _squares[i].gameObject.SetActive(false);
            }
        }

        void Update()
        {
            if (_currentIndex == _squares.Count)
            {
                Debug.Log("Win");
            }
            if (_decrementActive)
            {
                if (_currentIndex < 0)
                {
                    _decrementActive = false;
                    return;
                }
                _timer -= Time.deltaTime;

                if (_timer <= 0f)
                {
                    _squares[_currentIndex].SetActive(false);
                    if (_currentIndex > 0)
                    {
                        _currentIndex--;
                    }
                    _timer = _intervalBetweenSquares;
                }
            }
        }
 
        private void OnTriggerEnter2D(Collider2D other)
        {
            _decrementActive = true;
            if (_countParticles >= _particlesFrequence)
            {
                _squares[_currentIndex].SetActive(true);
                _currentIndex++;
                _countParticles = 0;
            }

            _countParticles++;
        }

        #endregion


        #region Main Methods

        //
    
        #endregion
        
    
        #region Utils
    
        /* Fonctions privées utiles */
    
        #endregion
    
    
        #region Privates and Protected

        [SerializeField] private List<GameObject> _squares = new List<GameObject>();
        [SerializeField] private float _intervalBetweenSquares = 0.5f;
        [SerializeField] private int _particlesFrequence = 5;
        
        private float _timer;
        private int _currentIndex = 0;
        private int _countParticles;
        private bool _decrementActive = false;

        #endregion
    }
}
