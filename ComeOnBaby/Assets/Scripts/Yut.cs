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
        float tossHeight = 3.0f; // 튕기는 높이
        float tossTime = 0.5f; // 튕기는 시간
        Vector3 originalPosition = transform.position;

        // 위로 튕기기
        Vector3 targetPosition = originalPosition + Vector3.up * tossHeight;
        float elapsedTime = 0f;

        // 위로 올라가기
        while (elapsedTime < tossTime)
        {
            transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / tossTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 약간의 공중에 떠있도록 조정
        yield return new WaitForSeconds(0.1f);

        // 떨어지기
        elapsedTime = 0f;
        while (elapsedTime < tossTime)
        {
            transform.position = Vector3.Lerp(targetPosition, originalPosition, elapsedTime / tossTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 결과 결정
        currentResult = Random.Range(0, 2) == 0 ? YutResult.Front : YutResult.Back;
        Debug.Log("윷 결과: " + currentResult);
    }
}