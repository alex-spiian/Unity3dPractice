using System;
using UnityEngine;

namespace DefaultNamespace
{
    
    [Serializable]
    public class StarController
    {
        [SerializeField] private ParticleSystem[] _particleSystems;
        
        public void StartStarsFall()
        {
            for (int i = 0; i < _particleSystems.Length; i++)
            {
                _particleSystems[i].Play();
                
            }
        }
    }
}