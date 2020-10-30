using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] float controlSpeed = 15f;
    [Tooltip("In ms")] [SerializeField] float xRange = 5f;
    [Tooltip("In ms")] [SerializeField] float yRange = 5f;

    [Header("Screen Position Based")]
    [SerializeField] float positionPitchFactor = -5f;

    [SerializeField] float controlPitchFactor = 5f;


    [Header("Control Throw Based")]
    [SerializeField] float positionYawFactor = -5f;
    [SerializeField] float controlRollFactor = -20f;
    [SerializeField] GameObject[] guns;

    float xThrow, yThrow;
    bool isControlEnabled = true;

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
    }

    private void StoppingPlayerMovement() // call by string reference
    {
        isControlEnabled = false;
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        // vertical
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * controlSpeed * Time.deltaTime;
        float rawNewYPos = transform.localPosition.y + yOffset; 
        float yPos = Mathf.Clamp(rawNewYPos, -yRange, yRange);

        // horizontal 
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float xPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);
        transform.localPosition = new Vector3(xPos, yPos, transform.localPosition.z);
    }

    private void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire")) 
        {
            print ("firing");
        }
    }
}
