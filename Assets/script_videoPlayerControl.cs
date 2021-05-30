using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class script_videoPlayerControl : MonoBehaviour
{
    public VideoPlayer vPlayer;
    // Start is called before the first frame update
    void Start()
    {

        vPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "vid_ending.mp4");

        // Add execution function to loopPointReached(Executed when video ends)
        // loopPointReachedに実行関数を追加(ビデオ終了時に実行される)
        vPlayer.loopPointReached += EndReached;

    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        // Load start menu scene
        // スタートメニューシーンの読み込み
        SceneManager.LoadScene("scene_start_menu");
    }
}
