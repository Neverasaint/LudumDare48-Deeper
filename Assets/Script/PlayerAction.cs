using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public TextMesh overheadText;
    // Start is called before the first frame update
    void Start()
    {
        if (overheadText == null)
            overheadText = transform.Find("OverheadText").GetComponent<TextMesh>();
     
        overheadText.text = null;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Action"))
           ActionButton.Instance.Action();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Environment"))
        {
            EnvironmentText envText= collision.GetComponent<EnvironmentText>();
            overheadText.text = envText.text;
            envText.stepped = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        overheadText.text = null;
    }
}
