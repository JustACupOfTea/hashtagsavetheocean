using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossStats : MonoBehaviour
{
    public static BossStats instance;
    [SerializeField] public int bossHealth;
    [SerializeField] public string level;
    public HealthBarBoss hpBarBoss;
    public Text bossName;
    public Timer timer;
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
        hpBarBoss.SetHealth(bossHealth);
        AkSoundEngine.PostEvent("Play_Slash", gameObject);
        AkSoundEngine.PostEvent("Play_Boss_Damage", gameObject);
    }
    
    public IEnumerator ReduceHealthDeath(int reduceBy)
    {
        bossHealth -= reduceBy;
        hpBarBoss.SetHealth(bossHealth);
        timer.Finish();
        PlayerStats.instance.finished = true;
        yield return new WaitForSeconds(5);
        hpBarBoss.gameObject.SetActive(false);
        bossName.gameObject.SetActive(false);
        SceneManager.LoadSceneAsync(level);
        AkSoundEngine.StopAll();
        AkSoundEngine.PostEvent("Play_Success", gameObject);
        AkSoundEngine.SetState("music", "win");
        AkSoundEngine.PostEvent("Play_OgreTHX", gameObject);
        GameObject.Find("XR Origin").transform.position= Vector3.zero;
    }
}
