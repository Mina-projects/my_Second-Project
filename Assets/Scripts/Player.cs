using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    [Tooltip("In ms^-1")]
    [SerializeField]
    float SpeedFactor = 4f;
    [SerializeField]
    float xRange = 0.06f;
    [SerializeField]
    float yRange = 0.6f;
    [SerializeField]
    float positionPitchFactor = -30f;
    [SerializeField]
    float controlPitchFactor = -86f;
    [SerializeField]
    float positionYawFactor = -10f;
    [SerializeField]
    float controlRollFactor = -40f;


    float horizonatlThrow, verticalThrow;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovementControl();
        RotationControl();    
    }  


    public void MovementControl()
    {
        horizonatlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // access to the horizontal and vertical axis of this game object
        verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = horizonatlThrow * SpeedFactor * Time.deltaTime; // controling speed with an offset
        float yOffset = verticalThrow * SpeedFactor * Time.deltaTime;

        float rawNewxPos = transform.localPosition.x + xOffset; // add the offset to the position, by this you can move the object. 
        float rawNewyPos = transform.localPosition.y + yOffset;

        float clampXPos = Mathf.Clamp(rawNewxPos, -xRange, xRange); // limiting the movements
        float clampYPos = Mathf.Clamp(rawNewyPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampXPos, clampYPos, transform.localPosition.z);
    }

    public void RotationControl()
    {
        //pitch
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = verticalThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        //yaw
        float yaw = transform.localPosition.x * positionYawFactor;

        //roll
        float roll = horizonatlThrow * controlRollFactor; 

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
