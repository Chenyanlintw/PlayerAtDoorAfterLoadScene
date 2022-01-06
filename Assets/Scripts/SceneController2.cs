using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController2 : MonoBehaviour
{
    // 裝場景上所有門的清單
    public List<Door> DoorList;

    // 玩家
    public Player player;


    void Start()
    {
        // 取得進來的門的ID
        string eid = GameData.PrevEntranceId;

        if (eid != null)
        {
            // 用 ID 到對應的門
            Door door = GetDoorById(eid);

            if (door)
            {
                // 向門要門口的座標
                Transform trans = door.GetFrontTransform();

                // 把玩家放到門口座標
                player.transform.position = trans.position;
                player.transform.rotation = trans.rotation;
            }
            else
            {
                Debug.Log("在這場景找不到門ID:" + eid);
            }
        }
    }

    // 用 ID 從清單中找出對應的門物件
    Door GetDoorById(string eid)
    {
        foreach(Door door in DoorList)
        {
            if (door.id == eid)
            {
                return door;
            }
        }
        return null;
    }
}
