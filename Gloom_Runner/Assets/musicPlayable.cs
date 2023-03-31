using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicPlayable : MonoBehaviour
{

    private static musicPlayable instance;
    // Start is called before the first frame update
    void Start()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
