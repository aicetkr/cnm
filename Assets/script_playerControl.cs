using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class script_playerControl : MonoBehaviour
{
    public int speed;
    public CharacterController player;
    public AudioSource sfxBreath;
    public AudioSource sfxStep;

    public Camera mainCam;
    public float moueSensitivity = 100f;
    float xRotation = 0f;
    public Light spotlight;

    public NavMeshAgent nAgent;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        movementUpdate();

        cameraUpdate();

        spotlightUpdate();
    }

    private void spotlightUpdate() {
        // Set spotlight orientation to the same as the main camera
        spotlight.transform.rotation = mainCam.transform.rotation;
    }

    // Set camera orientation to where the player face (matching camera rotation to mouse movement)
    private void cameraUpdate() {
        float mouseX = Input.GetAxis("Mouse X") * moueSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * moueSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Horizontal rotation
        mainCam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //Vertical rotation
        player.transform.Rotate(Vector3.up * mouseX);
    }

    /**
        Move character
     */
    private void movementUpdate() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        player.Move(move * speed * Time.deltaTime);

        if ((x > 0 || z > 0) && (!sfxStep.isPlaying))
        {
            sfxControl(true);
        }
        else if ((x == 0 && z == 0) && (sfxStep.isPlaying))
        {
            sfxControl(false);
        }
    }

    private void sfxControl(bool play) {
        if (play)
        {
            sfxBreath.Play();
            sfxStep.Play();
        }
        else {
            sfxBreath.Pause();
            sfxStep.Pause();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered: " + other.name);

        // Call for gameOver scene when the player gets in touch with N
        // プレイヤーがNと接触したときのgameOverシーンの呼び出し
        if (other.tag.Equals("N"))
            SceneManager.LoadScene("gameOver");

        // Teleport N to its warp point when player gets in touch with 
        // the teleportation trigger, and set for 10 seconds cooldown
        // before reactivating the trigger to prevent "double-trigger"
        // プレイヤーがテレポートトリガーに接触すると、Nをそのワープポイントにテレポートする。
        // テレポートのトリガーに触れるとNをワープポイントにテレポートし、10秒間のクールダウンを設定する。
        // "ダブルトリガー"を防ぐため
        if (other.name.Contains("TPT")) {
            nAgent.Warp(GameObject.Find(other.name.Replace("TPT", "TPD")).transform.position);
            other.gameObject.SetActive(false);
            StartCoroutine(activeAgain(other.gameObject));
        }

        // Disable pickable items when gets in touch to prevent 
        // the item being picked up again        
        // 接触(神絵師（たべもの）とプレーヤー)があったときにピックアップ可能なアイテムを無効にして 
        // 再度拾われないようにする
        if (other.tag.Equals("floatingItems"))
            other.gameObject.SetActive(false);

        // Call for gameClear scene when player reach the exit
        // Key availability check is unnecessary due to the exit block's existence
        // プレイヤーが出口に到達したらgameClearシーンを呼び出す
        // 出口ブロックが存在するため、キーの有効性チェックは不要
        if (other.name.Equals("ExitT")) { 
            SceneManager.LoadScene("gameClear");
        }
    }

    private IEnumerator activeAgain(GameObject gameObject)
    {
        yield return new WaitForSeconds(10);
        gameObject.SetActive(true);
        yield return null;
    }
}
