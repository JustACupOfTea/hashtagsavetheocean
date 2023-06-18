using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossStats : MonoBehaviour
{
    public static BossStats instance;
    [SerializeField] public int bossHealth;

        [SerializeField] private string level;
        
    
    // Start is called before the first frame update
     void Awake()
    {
        if (instance == null)
        {
            instance = this;
         
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ReduceHealth(int reduceBy)
    {
        bossHealth -= reduceBy;
        //Update hpbar

        if (bossHealth <= 0)
        {
            

            SceneManager.LoadSceneAsync(level);
            Destroy(gameObject);
        }
            
    }
}
