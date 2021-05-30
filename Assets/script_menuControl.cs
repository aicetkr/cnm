using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 *  
 */
public class script_menuControl : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        checkKeyDownAndExecute();
    }

    /**
        Executes all input checks and run its relative function
        すべての入力チェックを実行し、その相対的な機能を実行する
     */
    private void checkKeyDownAndExecute() {
        // Add your input check here
        if (Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene("scene_gameplay");
    }
}
