using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadTheScene", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadTheScene()
    {
        SceneManager.LoadScene(1);
    }
}
