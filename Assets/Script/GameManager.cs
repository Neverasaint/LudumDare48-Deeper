using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float loadSceneDelay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    private IEnumerator LoadScene(int index)
    {
        yield return new WaitForSeconds(loadSceneDelay);
        SceneManager.LoadScene(index);
    }

    public void NextScene()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }
}
