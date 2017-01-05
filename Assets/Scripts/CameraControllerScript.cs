﻿using UnityEngine;
using System.Collections;

public class CameraControllerScript : MonoBehaviour {

    public Transform VRcam;  // drag the child VR cam here in the inspector

    public void Recenter()
    {
      transform.localRotation = Quaternion.Inverse(VRcam.rotation);
    }
    
}
