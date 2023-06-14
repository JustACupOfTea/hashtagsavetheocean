using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAnimationScript : MonoBehaviour
{
    public void OnGrabRemoveScript()
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        Animation a = transform.GetComponent<Animation>();
        Destroy(a);
    }
}
