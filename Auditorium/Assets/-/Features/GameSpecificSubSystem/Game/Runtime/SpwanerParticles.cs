using System.Timers;
using UnityEngine;

namespace Game.Runtime
{
    public class SpwanerParticles : MonoBehaviour
    {


        #region Publics

        //
    
        #endregion


        #region Unity API

        void Awake()
        {
            //
        }
        
        // Update is called once per frame
        void Update()
        {
            for (var i = 0; i < _maxParticles; i++)
            {
                Debug.Log("Valeur i : " + i.ToString());
                CreateTimer(1.0f);
                _instance = Instantiate<GameObject>(_particlePrefab, transform);
                _instance.transform.position = transform.position;
                var rbInstance = _instance.GetComponent<Rigidbody2D>();
                rbInstance.AddForce(Vector2.left * 20.0f);
            }
        }

        #endregion
    


        #region Main Methods

        //
    
        #endregion

    
        #region Utils
    
        /* Fonctions privées utiles */
        private void CreateTimer(float seconds)
        {
            float timer = seconds;
            timer -= Time.deltaTime;
            if (seconds <= 0)
            {
                timer = seconds;
            }
        }
    
        #endregion
    
    
        #region Privates and Protected

        [SerializeField] private GameObject _particlePrefab;
        [SerializeField] private int _maxParticles;
        
        GameObject _instance;

        #endregion
    }
}
