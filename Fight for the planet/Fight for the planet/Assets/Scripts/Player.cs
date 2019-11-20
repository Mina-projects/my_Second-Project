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
        float horizonatlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // access to the horizontal and vertical axis of this game object
        float verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = horizonatlThrow * SpeedFactor * Time.deltaTime; // controling speed with an offset
        float yOffset = verticalThrow * SpeedFactor * Time.deltaTime;

        float rawNewxPos = transform.localPosition.x + xOffset; // add the offset to the position
        float rawNewyPos = transform.localPosition.y + yOffset;

        float clampXPos = Mathf.Clamp(rawNewxPos, -xRange, xRange); // limiting the movements
        float clampYPos = Mathf.Clamp(rawNewyPos, -yRange, yRange);


        transform.localPosition = new Vector3(clampXPos, clampYPos, transform.localPosition.z);
    }

    public void RotationControl()
    {
        transform.localRotation = Quaternion.Euler(0, 90, 0);
    }
}
