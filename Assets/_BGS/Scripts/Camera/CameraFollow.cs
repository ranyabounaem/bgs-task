using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGS.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField]
        Transform target;
        void Update()
        {
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        }
    }
}

