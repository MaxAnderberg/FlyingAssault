using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 10f;
    [Tooltip("In ms")] [SerializeField] float xRange = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float xPos = Mathf.Clamp(rawNewXPos,-xRange, xRange);
        transform.localPosition = new Vector3(xPos, transform.localPosition.y, transform.localPosition.z);

    }
}
