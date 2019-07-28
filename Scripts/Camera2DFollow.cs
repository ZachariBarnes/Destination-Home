using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour
    {
        public GameObject player;

        public Vector3 offset;

        // Use this for initialization
        private void Start()
        {
            offset = transform.position - player.transform.position;
        }


        // Update is called once per frame
        private void LateUpdate()
        {
            transform.position = player.transform.position + offset;
        }
    }
}
