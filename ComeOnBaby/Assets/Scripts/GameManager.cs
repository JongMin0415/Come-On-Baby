using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public YutController yutController;

    public void OnThrowButtonClick()
    {
        Debug.Log("버튼이 클릭되었습니다."); // 디버그 메시지 추가
        yutController.ThrowYut();
        // 일정 시간 후에 윷의 결과를 확인
        Invoke("CheckResult", 2f); // 2초 후 결과 체크
    }

    void CheckResult()
    {
        yutController.CheckYutResult(); // public 메서드 호출
    }
}