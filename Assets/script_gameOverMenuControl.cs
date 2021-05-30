using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class script_gameOverMenuControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkKeyDownAndExecute();

    }

    /**
    Executes all input checks and run its relative function
 */
    private void checkKeyDownAndExecute()
    {
        // Add your input check here
        if (Input.GetKeyDown(KeyCode.Y))
            SceneManager.LoadScene("scene_start_menu");
    }
}
