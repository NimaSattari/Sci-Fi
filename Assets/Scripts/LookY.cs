using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    [SerializeField] float Sensitivity = 2f;

    void Update()
    {
        float MouseY = Input.GetAxis("Mouse Y");
        Vector3 newRotation = transform.localEulerAngles;
        newRotation.x -= MouseY * Sensitivity;
        transform.localEulerAngles = newRotation;
    }
}
