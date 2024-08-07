// # Systems
using System.Collections;
using System.Collections.Generic;

// # Unity
using UnityEngine;
/// <summary>
/// 배경스크롤
/// </summary>
public class BackGroundMove : MonoBehaviour
{
    [SerializeField] private Transform target;
    private readonly float scrollRange = 20f;
    private readonly float moveSpeed = 3.0f;
    private Vector3 moveDirection = Vector3.down;

    private void Update()
    {
        // Background move to moveDirection, speed = moveSpeed;
        transform.position += moveSpeed * Time.deltaTime * moveDirection;


        // 배경이 설정된 범위를 벗어나면 위치 재설정
        if (transform.position.y <= -scrollRange)
        {
            transform.position = target.position + Vector3.up * scrollRange;
        }
    }
}
