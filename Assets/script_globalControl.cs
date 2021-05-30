using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Controls global operations like Esc (exiting the game)
 * Should be added to every root of any scene
 */
public class script_globalControl : MonoBehaviour
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
    private void checkKeyDownAndExecute()
    {
        // Add your input check and its execution here
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}
