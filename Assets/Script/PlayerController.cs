using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Animator anime;
    public FloatingJoystick joystick;

    [System.NonSerialized]
    public Vector3 desiredPos;
    private TimeBody time;

    private void Start()
    {
        time = GetComponent<TimeBody>();
        if (joystick == null)
        {
            joystick = GameObject.Find("Floating Joystick").GetComponent<FloatingJoystick>();
        }

        if (anime == null)
        {
            anime = GetComponent<Animator>();
        }
    } 

    // Update is called once per frame
    private void Update()
    {
        if (!time.isRewinding)
        {
            desiredPos.x = joystick.isOn ? joystick.Horizontal : Input.GetAxis("Horizontal");
            desiredPos.y = joystick.isOn ? joystick.Vertical : Input.GetAxis("Vertical");
        }
            anime.SetFloat("Horizontal", desiredPos.x);
            anime.SetFloat("Vertical", desiredPos.y);
            anime.SetFloat("Speed", desiredPos.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        if(!time.isRewinding)
        transform.position = Vector3.MoveTowards(transform.position, transform.position + desiredPos, moveSpeed/10);
    }
}
