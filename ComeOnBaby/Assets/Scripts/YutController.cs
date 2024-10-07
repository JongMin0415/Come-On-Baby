using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YutController : MonoBehaviour
{
    public float bounceHeight = 2f; // 튕기는 높이
    public float bounceDuration = 0.5f; // 튕기는 시간
    private bool isBouncing = false;

    // 텍스처를 위한 변수
    public Material frontMaterial; // 앞면 재질
    public Material backMaterial; // 뒷면 재질

    // 윷의 앞면과 뒷면 상태를 저장
    private int frontCount = 0; // 앞면의 갯수

    private void Start()
    {
        UpdateMaterial();
    }

    public void Bounce()
    {
        if (!isBouncing)
        {
            frontCount = 0; // 던질 때마다 초기화
            StartCoroutine(BounceCoroutine());
        }
    }

    private IEnumerator BounceCoroutine()
    {
        isBouncing = true;
        Vector3 originalPosition = transform.position;
        Vector3 targetPosition = originalPosition + Vector3.up * bounceHeight;

        // 최소 한 바퀴 회전
        float totalRotationAngle = 360f; // 1 바퀴
        float elapsedTime = 0f;

        // 위로 튕기기
        while (elapsedTime < bounceDuration)
        {
            float t = elapsedTime / bounceDuration;
            transform.position = Vector3.Lerp(originalPosition, targetPosition, t);
            transform.Rotate(0, 0, totalRotationAngle * Time.deltaTime / bounceDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 아래로 떨어지기
        elapsedTime = 0f;
        while (elapsedTime < bounceDuration)
        {
            float t = elapsedTime / bounceDuration;
            transform.position = Vector3.Lerp(targetPosition, originalPosition, t);
            transform.Rotate(0, 0, totalRotationAngle * Time.deltaTime / bounceDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 바닥에 멈춘 후 위쪽 방향 확인
        UpdateMaterialBasedOnRotation();

        // 디버그 출력
        Debug.Log("멈춘 후 상태를 확인합니다."); // 멈춘 후 상태 확인 메시지

        isBouncing = false;
    }

    private void UpdateMaterialBasedOnRotation()
    {
        // 오브젝트가 위를 향하는지 판단
        if (transform.up.y > 0) // Y축이 위쪽을 향하고 있다면
        {
            GetComponent<Renderer>().material = frontMaterial; // 앞면 재질
            frontCount++; // 앞면 카운트 증가
            Debug.Log("앞면이 위로 향하고 있습니다."); // 디버그 출력
        }
        else
        {
            GetComponent<Renderer>().material = backMaterial; // 뒷면 재질
            Debug.Log("뒷면이 위로 향하고 있습니다."); // 디버그 출력
        }
    }

    // 앞면의 개수를 반환하는 메서드
    public int GetFrontCount()
    {
        return frontCount;
    }

    private void UpdateMaterial()
    {
        // 초기 상태에서 재질 설정
        UpdateMaterialBasedOnRotation();
    }
}
