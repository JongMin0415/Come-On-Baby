using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Transform> boardPositions; // ���� ���� ��� ��ǥ��
    private int currentPlayerPosition = 0; // ���� �÷��̾��� ��ġ �ε���
    public YutController yutController; // �� ������ ��Ʈ�ѷ�
    public int stepsToMove; // ���� ���� ����� ���� ������ ĭ ��

    private void Start()
    {
        // �ʱ� ��ġ ����
        UpdatePlayerPosition();
    }

    // �÷��̾ ���� ����
    public void ThrowYut()
    {
        yutController.Bounce();
        StartCoroutine(WaitForYutResult());
    }

    private IEnumerator WaitForYutResult()
    {
        // �� ������ �ִϸ��̼ǰ� ��� ���
        yield return new WaitForSeconds(2f); // ���� ���� ������ ���
        CalculateYutResult();
        MovePlayer();
    }

    private void CalculateYutResult()
    {
        // ���� ����� ���� �̵� ĭ�� ����
        int frontCount = yutController.GetFrontCount(); // �ո��� ���� ��������

        switch (frontCount)
        {
            case 0:
                stepsToMove = 4; // ��
                break;
            case 1:
                stepsToMove = 1; // ��
                break;
            case 2:
                stepsToMove = 2; // ��
                break;
            case 3:
                stepsToMove = 3; // ��
                break;
            case 4:
                stepsToMove = 5; // ��
                break;
            default:
                stepsToMove = 0; // �߸��� ���
                break;
        }

        Debug.Log("�̵��� ĭ ��: " + stepsToMove);
    }

    private void MovePlayer()
    {
        // ���� �÷��̾��� ��ġ ������Ʈ
        currentPlayerPosition += stepsToMove;

        // ��ġ�� ������ ������ �ʰ��ϸ� �����ϵ��� ����
        if (currentPlayerPosition >= boardPositions.Count)
        {
            currentPlayerPosition %= boardPositions.Count;
        }

        // �÷��̾��� ���� ��ġ�� ����
        UpdatePlayerPosition();
    }

    private void UpdatePlayerPosition()
    {
        // ���� ��ġ�� ���� �����ǿ��� �÷��̾ ǥ���մϴ�.
        Debug.Log("���� �÷��̾� ��ġ: " + currentPlayerPosition);
        // �̰����� ������ �÷��̾��� ��ġ�� ǥ���� �� �ֵ��� �߰� �ڵ� �ۼ�
        // ��: Ư�� ���� ������Ʈ�� ��ġ�� ������Ʈ�ϴ� �ڵ�
        // playerGameObject.transform.position = boardPositions[currentPlayerPosition].position;
    }
}