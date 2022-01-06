using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    // 門的 ID
    public string id = null;

    // 要傳送的場景編號
    public int GoToSceneId = 0; 


    // 當碰撞發生
    private void OnTriggerEnter(Collider other)
    {
        // 判斷是不是玩家
        if (other.tag == "Player")
        {
            // 紀錄門的ID
            GameData.PrevEntranceId = id;
          
            // 切換場景
            SceneManager.LoadScene(GoToSceneId);
        }
    }

    // 取得門前的座標（第一個小孩 empty）
    public Transform GetFrontTransform()
    {
        return transform.GetChild(0);
    }
}
