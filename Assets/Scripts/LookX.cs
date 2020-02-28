using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
{
    [SerializeField] float Sensitivity = 2f;

    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X");
        Vector3 newRotation = transform.localEulerAngles;
        newRotation.y += MouseX * Sensitivity;
        transform.localEulerAngles = newRotation;
    }
}
