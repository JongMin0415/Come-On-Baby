using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public YutController yutController;

    public void OnThrowButtonClick()
    {
        Debug.Log("��ư�� Ŭ���Ǿ����ϴ�."); // ����� �޽��� �߰�
        yutController.ThrowYut();
        // ���� �ð� �Ŀ� ���� ����� Ȯ��
        Invoke("CheckResult", 2f); // 2�� �� ��� üũ
    }

    void CheckResult()
    {
        yutController.CheckYutResult(); // public �޼��� ȣ��
    }
}