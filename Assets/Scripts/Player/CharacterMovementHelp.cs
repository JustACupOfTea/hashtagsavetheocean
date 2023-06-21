using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.XR.Interaction.Toolkit;

/*
 * This class smoothens the movement of the player
 */
public class CharacterMovementHelp : MonoBehaviour
{
    private XROrigin m_XROrigin;
    private CharacterController m_CharacterController;
    private CharacterControllerDriver driver;

    // Update is called once per frame
    void Update()
    {
        UpdateCharacterController();  
    }
    
    protected virtual void UpdateCharacterController()
    {
        if (m_XROrigin == null || m_CharacterController == null)
            return;
        
        // Adjust center of camera
        var height = Mathf.Clamp(m_XROrigin.CameraInOriginSpaceHeight, driver.minHeight, driver.maxHeight);

        Vector3 center = m_XROrigin.CameraInOriginSpacePos;
        center.y = height / 2f + m_CharacterController.skinWidth;

        m_CharacterController.height = height;
        m_CharacterController.center = center;
    }
}