using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Abstract.Controllers
{
    public class MyCharacterController : MonoBehaviour
    {
        [SerializeField] float _moveBoundary = 4f;
        [SerializeField] protected float _movementSpeed;

        public float MoveSpeed => _movementSpeed;
        public float MoveBoundary => _moveBoundary;
    }
}

