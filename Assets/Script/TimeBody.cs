using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    public float recordTime = 5f;
    [System.NonSerialized]
    public bool isRewinding = false;
    private List<PointInTime> pointInTimes;
    private PlayerController player;
    void Start()
    {
        player = GetComponent<PlayerController>();
        pointInTimes = new List<PointInTime>();
    }

   
    private void FixedUpdate()
    {
        if (isRewinding)
        {
            Rewinding();
        }
        else
        {
            Record();
        }
    }
    private void Rewinding()
    {
        if (pointInTimes.Count > 0)
        {
            PointInTime pointInTime = pointInTimes[0];
            transform.position = pointInTime.position;
            player.desiredPos = pointInTime.desiredPos;
            pointInTimes.RemoveAt(0);
        }
        else
            StopRewinding();
    }
    private void Record()
    {
        if (pointInTimes.Count > Mathf.Round( recordTime / Time.fixedDeltaTime))
            pointInTimes.RemoveAt(pointInTimes.Count - 1);
        pointInTimes.Insert(0, new PointInTime(transform.position, player.desiredPos));
    }
    public void StartRewinding()
    {
        isRewinding = true;
    }

    public void StopRewinding()
    {
        isRewinding = false;
    }
}
