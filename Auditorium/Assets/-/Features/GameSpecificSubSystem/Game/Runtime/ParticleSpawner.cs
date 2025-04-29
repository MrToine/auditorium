using System.Timers;
using UnityEngine;

namespace Game.Runtime
{
    public class ParticleSpawner : MonoBehaviour
    {
        #region Publics

        //
    
        #endregion


        #region Unity API

        void Start()
        {
            _timer = _spawnInterval;
        }
        
        // Update is called once per frame
        void Update()
        {
            _timer -= Time.deltaTime;         
            if (_timer <= 0f)
            {
                SpawnBatch();
                _timer = _spawnInterval; 
            } 
        }

        #endregion
    


        #region Main Methods

        //
    
        #endregion

    
        #region Utils
    
        /* Fonctions privées utiles */
        private void SpawnBatch()
        {
            for (int i = 0; i < _maxParticles; i++)
            {
                Vector2 randomOffset = Random.insideUnitCircle * _spawnRadius;
                Vector2 spawnPosition = (Vector2)transform.position + randomOffset;
                Quaternion rotation = Quaternion.Euler(0, 0, _particleRotation);
                var instance = Instantiate(_particlePrefab, spawnPosition, rotation, transform);
                var rb = instance.GetComponent<Rigidbody2D>();
                Vector2 direction = instance.transform.right;
                
                rb.AddForce(direction * _particleSpeed);
            }
        }
    
        #endregion
    
    
        #region Privates and Protected

        [SerializeField] private GameObject _particlePrefab;
        [SerializeField] private int _maxParticles;
        [SerializeField] private float _spawnInterval = 1f;
        [SerializeField] private float _particleRotation = 45f;
        [SerializeField] private float _spawnRadius = 1f;
        [SerializeField] private float _particleSpeed = 15f;
        
        GameObject _instance;

        private float _timer;

        #endregion
    }
}
