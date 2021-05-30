using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script_hudUIControl : MonoBehaviour
{
    private GameObject[] pickables;
    // Start is called before the first frame update
    void Start()
    {
        pickables = GameObject.FindGameObjectsWithTag("floatingItems");
    }

    // Update is called once per frame
    void Update()
    {
        updatePickableStatus();
    }

    private void updatePickableStatus() {
        // Iterates through each pickables items and light it up in the GUI if it is picked up
        // 各アイテム(神絵師（たべもの）)をイテレートして、ピックアップされたらGUIに表示する
        foreach (GameObject p in pickables) {
            if (!p.active)
                (GameObject.Find(p.name + "UI").GetComponent("RawImage") as RawImage).color = Color.white;
        }
    }
}
