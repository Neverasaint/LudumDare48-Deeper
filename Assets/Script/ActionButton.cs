using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ActionButton : MonoBehaviour
{
    public static ActionButton Instance;
    public Text buttonText;
    public TimeBody time;

    private void Start()
    {
        Instance = this;

        if (buttonText == null)
            buttonText = transform.Find("Text").GetComponent<Text>();
    }

    public void Action()
    {
        time.StartRewinding();
    }

        
}
