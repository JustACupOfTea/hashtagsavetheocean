using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        var part = GetComponent<ParticleSystem>();
        part.Play();
        Destroy(gameObject,part.main.duration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
