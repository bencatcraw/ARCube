using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;
public class Interact : MonoBehaviour
{
    [SerializeField] private Transform dLight;
    public float rotationSpeed = 20f;

    private bool isFingerDown = false;

    private void OnEnable()
    {
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();
        EnhancedTouch.Touch.onFingerDown += FingerDown;
        EnhancedTouch.Touch.onFingerUp += FingerUp;
    }

    private void OnDisable()
    {
        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.EnhancedTouchSupport.Disable();
        EnhancedTouch.Touch.onFingerDown -= FingerDown;
        EnhancedTouch.Touch.onFingerUp -= FingerUp;
    }

    private void FingerDown(EnhancedTouch.Finger finger)
    {
        if (finger.index != 0) return;

        isFingerDown = true;
    }

    private void FingerUp(EnhancedTouch.Finger finger)
    {
        if (finger.index != 0) return;

        isFingerDown = false;
    }

    private void Update()
    {
        if (isFingerDown)
        {
            float rotationAmt = rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.right * rotationAmt);
        }
    }
}
