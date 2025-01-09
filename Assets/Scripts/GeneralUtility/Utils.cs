using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static class Utils
    {
        public static Quaternion LookAt2d(this GameObject GameObject, GameObject TargetGameObject)
        {
            GameObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, TargetGameObject.transform.position - TargetGameObject.transform.position);
            return GameObject.transform.rotation;
        }
    }
}
