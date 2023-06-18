using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHitbox : MonoBehaviour
{
    [SerializeField] public int playerDamageToBoss;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sword")
        {
            transform.GetComponentInParent<BossStats>().ReduceHealth(playerDamageToBoss);
            Debug.Log("Boss DMG: 10");
        }
    }
}
