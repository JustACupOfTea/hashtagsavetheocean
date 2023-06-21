using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

/*
 * This class uses the path calculated from the A* to travel to the destination
 */
public class Animation : MonoBehaviour
{
    public GameObject aStar;
    public Pathfinding gridPath;
    
    private int _currentPathID = 0;
    private int _nextPathID = 1;
    private float _rotateSpeed = 3.0f;
    private float _accumulatedTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // Quit if there is no path
        if (gridPath.path.Count <= 1)
            return;
        
        WalkForward();
        
        // If the destination is reached the object gets destroyed
        if (_currentPathID == _nextPathID)
        {
            uint[] playingIds = new uint[1];
            uint count = (uint)playingIds.Length;
            // Get all playing ids from currently playing sounds on this object
            AkSoundEngine.GetPlayingIDsFromGameObject(transform.GetChild(0).gameObject, ref count, playingIds);
            uint playingId = playingIds[0];
            AkSoundEngine.StopPlayingID(playingId);
            Destroy(gameObject);
            PlayerStats.instance.IncreaseHealth(10);
        }
    }

    void WalkForward()
    {
        // Rotate towards the target
        transform.forward = Vector3.RotateTowards(transform.forward,
            gridPath.path[_nextPathID].position - transform.position,
            _rotateSpeed * Time.deltaTime, 0.0f);
        
        // Move the object to the target
        _accumulatedTime += Time.deltaTime;
        transform.position = EaseInOut.MoveTowardSmoothstep(gridPath.path[_currentPathID].position,
            gridPath.path[_nextPathID].position, _accumulatedTime);
        
        if (transform.position == gridPath.path[_nextPathID].position)
        {
            // Increase the current and check if the path end has been reached -> If not increase the next id
            _currentPathID++;
            if (_currentPathID < gridPath.path.Count-1)
            {
                _nextPathID++;
                _accumulatedTime = 0;
            }
        }
    }
}
