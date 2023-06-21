using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class is used by the xr rig, so that the garbage a player grabs doesn't go back to travelling to the ocean
 */
public class RemoveAnimationScript : MonoBehaviour
{
    public void OnGrabRemoveScript()
    {
        // Remove the animation scripts
        Animation a = transform.GetComponent<Animation>();
        Destroy(a);
        AkSoundEngine.PostEvent("Play_Grab", gameObject);
    }
}
