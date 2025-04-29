using System;
using UnityEngine;

namespace Game.Runtime
{
    public class DragAndDrop : MonoBehaviour
    {
        #region Publics
        
        //
    
        #endregion


        #region Unity API

        void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _transform  = transform;
            _mousePosition = Input.mousePosition;
        }
        
        // Update is called once per frame
        void Update()
        {
            MouseDrag();
        }
        

        private void OnMouseDown()
        {
            _spriteRenderer.color = Color.yellow;
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            _canTake = true;
        }

        private void OnMouseUp()
        {
            _spriteRenderer.color = Color.white;
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            _canTake = false;
        }

        #endregion
    


        #region Main Methods

        //
    
        #endregion

    
        #region Utils
    
        /* Fonctions privées utiles */
        private void MouseDrag()
        {
            if (_canTake)
            {
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mouseWorldPos.z = 0;
                transform.position = mouseWorldPos;
            }
        }
    
        #endregion
    
    
        #region Privates and Protected

        private bool _canTake = false;
        private Transform _transform;
        private Vector2 _mousePosition;
        
        private SpriteRenderer _spriteRenderer;

        #endregion
    }
}
