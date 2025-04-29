using UnityEngine;

namespace Game.Runtime
{
    public class Arrow : MonoBehaviour
    {
        #region Publics

        //
    
        #endregion


        #region Unity API

        void Start()
        {
            Quaternion rotation = Quaternion.Euler(0, 0, _arrowDirection);
            transform.rotation = rotation;
        }
        
        // Update is called once per frame
        void Update()
        {
            //
        }

        #endregion
    


        #region Main Methods

        //
    
        #endregion

    
        #region Utils
    
        /* Fonctions privées utiles */
    
        #endregion
    
    
        #region Privates and Protected

        [SerializeField] private float _arrowDirection = 0f;

        #endregion
    }
}
