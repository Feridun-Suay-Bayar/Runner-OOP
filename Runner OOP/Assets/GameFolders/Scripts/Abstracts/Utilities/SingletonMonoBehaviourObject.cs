using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Abstract.Utilities
{
    public abstract class SingletonMonoBehaviourObject<T> : MonoBehaviour where T : Component
    {
        public static T Instance { get; private set; }

        public void SingletonThisObject(T entity) 
        { 
            if(Instance == null)
            {
                Instance = entity;
                DontDestroyOnLoad(entity);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}

