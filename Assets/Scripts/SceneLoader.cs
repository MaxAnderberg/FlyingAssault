﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadFirstLevel", 3f);
    }
    void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }
}

// Update is called once per frame
void Update()
    {
        
    }
}
