using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string levelToLoadName;
    public int levelToLoadIndex;
    public bool loadLevelByName;


    // Start is called before the first frame update
    void Start()
    {
        if (loadLevelByName)
        {
            //Loads the scence by name
            SceneManager.LoadScene(levelToLoadName);
        }
        else
        {
            //
            //
            SceneManager.LoadScene(levelToLoadIndex);
        }
    }

}
