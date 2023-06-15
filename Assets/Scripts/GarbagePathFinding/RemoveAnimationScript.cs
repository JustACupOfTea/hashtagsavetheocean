using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAnimationScript : MonoBehaviour
{
    public void OnGrabRemoveScript()
    {
        Animation a = transform.GetComponent<Animation>();
        Destroy(a);
    }
}
