using System;
using UnityEngine;

namespace Game.Runtime
{
    public class Scaler : MonoBehaviour
    {


        #region Publics

        //
    
        #endregion


        #region Unity API


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _parent = GetComponentInParent<Transform>();
            _camera = Camera.main;
            _mousePosition = Input.mousePosition;
            _maxScale = transform.localScale.x * 2;
            _minScale = transform.localScale.x / 3;
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnMouseOver()
        {
            float newRadius = Vector2.Distance(transform.position, _camera.ScreenToWorldPoint(_mousePosition));
            if (newRadius >= _maxScale || newRadius < _minScale)
            {
                Debug.Log("dans le if");
                _mouseOverBorder = false;
            }
            else
            {
                Debug.Log("dans le else");
                _mouseOverBorder = true;
                var newScale = new Vector3(_previousScale.x + 0.1f, _previousScale.x + 0.1f, 0);
                transform.localScale = (newScale.x >= _maxScale || newScale.x <= _minScale) ? newScale : _previousScale;
            }
            
        }

        private void OnMouseDrag()
        { 
            Debug.Log("Go pour le drag");
            if (_mouseOverBorder)
            {
                float newRadius = Vector2.Distance(transform.position, _camera.ScreenToWorldPoint(_mousePosition));
                float clampedScale = Mathf.Clamp(newRadius * 2, _minScale, _maxScale);
                
                _parent.localScale = new Vector3(clampedScale, clampedScale, 1f);
                _previousScale = _parent.localScale;
            }
        }

        #endregion
    


        #region Main Methods

        //
    
        #endregion

    
        #region Utils
    
        /* Fonctions privées utiles */
    
        #endregion
    
    
        #region Privates and Protected

        private Camera _camera;
        private Vector2 _mousePosition;
        private float _maxScale;
        private float _minScale;
        private Vector3 _previousScale;
        private bool _mouseOverBorder = false;
        private bool _canScale = true;
        private Transform _parent;

        #endregion
    }
}
