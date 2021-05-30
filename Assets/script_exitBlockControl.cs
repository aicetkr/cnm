using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_exitBlockControl : MonoBehaviour
{
    public GameObject key;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Remove the obstacles at exit when key(pickable) is inactive (already picked up)
        // Key(Pickable)が非アクティブ(既にピックアップされている)時に出口で障害物を取り除く
        if (!key.active)
            gameObject.SetActive(false);
    }
}
