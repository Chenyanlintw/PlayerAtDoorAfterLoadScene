using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController controller;

    public float speed = 10;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // 取得方向鍵輸入
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 整合成向量
        Vector3 dir = new Vector3(h, 0, v).normalized;

        // 轉向
        if (dir.magnitude > 0.1f)
        {
            float faceAngle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, faceAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.3f);
        }

        // 移動角色
        controller.Move(dir * Time.deltaTime * speed);
    }
}
