using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform playerPiece; // 플레이어의 말
    public int currentPosition = 0; // 현재 말의 위치 (보드의 인덱스)

    // 말 이동 로직
    public void Move(int steps, List<Transform> boardPositions)
    {
        StartCoroutine(MoveCoroutine(steps, boardPositions));
    }

    private IEnumerator MoveCoroutine(int steps, List<Transform> boardPositions)
    {
        for (int i = 0; i < steps; i++)
        {
            currentPosition++;
            if (currentPosition >= boardPositions.Count)
            {
                currentPosition = boardPositions.Count - 1; // 보드 끝에 도달하면 멈춤
                Debug.Log("목적지에 도달했습니다!");
                break;
            }
            playerPiece.position = boardPositions[currentPosition].position;
            yield return new WaitForSeconds(0.5f); // 이동 시간
        }
    }
}