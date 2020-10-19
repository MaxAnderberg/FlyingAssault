using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 15f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 15f; // atm I'm not using this. Only using the xSpeed for both vertically and horizontal movement

    [Tooltip("In ms")] [SerializeField] float xRange = 5f;
    [Tooltip("In ms")] [SerializeField] float yRange = 5f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = -5f;
    [SerializeField] float controlPitchFactor = 5f;
    [SerializeField] float controlRollFactor = -20f;


    float xThrow, yThrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();

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
        float yOffset = yThrow * xSpeed * Time.deltaTime;
        float rawNewYPos = transform.localPosition.y + yOffset;
        float yPos = Mathf.Clamp(rawNewYPos, -yRange, yRange);

        // horizontal 
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float xPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);
        transform.localPosition = new Vector3(xPos, yPos, transform.localPosition.z);
    }
}
