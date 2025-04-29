using System;
using UnityEngine;

namespace Game.Runtime
{
    public class Particle : MonoBehaviour
    {
        #region Publics

        //
    
        #endregion


        #region Unity API

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Arrow"))
            {
                Debug.Log("particle on collision with : " + collision.gameObject.name);
                float zRotation = collision.transform.eulerAngles.z;
                float zRotationRad = zRotation * Mathf.Deg2Rad;

                Vector2 direction = new Vector2(Mathf.Cos(zRotationRad), Mathf.Sin(zRotationRad));
                _rb.AddForce(direction.normalized * _forceAmount,  ForceMode2D.Impulse);
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

        [SerializeField] private float _forceAmount = 100f;
        private Rigidbody2D _rb;

        #endregion
    }
}
