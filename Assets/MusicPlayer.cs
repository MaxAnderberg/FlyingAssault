using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MusicPlayer : MonoBehaviour
{


    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }


// Start is called before the first frame update
void Start()
    {
        Invoke("LoadFirstLevel",3f);
        
    }


    void LoadFirstLevel(){
        SceneManager.LoadScene(1);
    }


}
