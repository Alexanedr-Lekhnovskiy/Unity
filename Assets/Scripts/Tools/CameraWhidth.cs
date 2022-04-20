using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [RequireComponent(typeof(Camera))]
    public class CameraWhidth : MonoBehaviour
    {
        private const float Width = 1080f;
        private const float HalfSizedInPixels = 200f;

        private void Awake()
        {
            GetComponent<Camera>().orthographicSize = Width * Screen.height / Screen.width / HalfSizedInPixels;

        }
    }
 