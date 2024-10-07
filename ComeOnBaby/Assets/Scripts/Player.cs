using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform playerPiece; // �÷��̾��� ��
    public int currentPosition = 0; // ���� ���� ��ġ (������ �ε���)

    // �� �̵� ����
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
                currentPosition = boardPositions.Count - 1; // ���� ���� �����ϸ� ����
                Debug.Log("�������� �����߽��ϴ�!");
                break;
            }
            playerPiece.position = boardPositions[currentPosition].position;
            yield return new WaitForSeconds(0.5f); // �̵� �ð�
        }
    }
}