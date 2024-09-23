using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yut : MonoBehaviour
{
    public enum YutResult { Front, Back }
    public YutResult currentResult;

    public void Roll()
    {
        StartCoroutine(TossYut());
    }

    private IEnumerator TossYut()
    {
        float tossHeight = 3.0f; // ƨ��� ����
        float tossTime = 0.5f; // ƨ��� �ð�
        Vector3 originalPosition = transform.position;

        // ���� ƨ���
        Vector3 targetPosition = originalPosition + Vector3.up * tossHeight;
        float elapsedTime = 0f;

        // ���� �ö󰡱�
        while (elapsedTime < tossTime)
        {
            transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / tossTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // �ణ�� ���߿� ���ֵ��� ����
        yield return new WaitForSeconds(0.1f);

        // ��������
        elapsedTime = 0f;
        while (elapsedTime < tossTime)
        {
            transform.position = Vector3.Lerp(targetPosition, originalPosition, elapsedTime / tossTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // ��� ����
        currentResult = Random.Range(0, 2) == 0 ? YutResult.Front : YutResult.Back;
        Debug.Log("�� ���: " + currentResult);
    }
}