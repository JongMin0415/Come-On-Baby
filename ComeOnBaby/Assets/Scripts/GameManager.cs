using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Transform> boardPositions; // 게임 판의 경로 좌표들
    private int currentPlayerPosition = 0; // 현재 플레이어의 위치 인덱스
    public YutController yutController; // 윷 던지기 컨트롤러
    public int stepsToMove; // 윷을 던진 결과에 따라 움직일 칸 수

    private void Start()
    {
        // 초기 위치 설정
        UpdatePlayerPosition();
    }

    // 플레이어가 윷을 던짐
    public void ThrowYut()
    {
        yutController.Bounce();
        StartCoroutine(WaitForYutResult());
    }

    private IEnumerator WaitForYutResult()
    {
        // 윷 던지는 애니메이션과 결과 대기
        yield return new WaitForSeconds(2f); // 윷이 멈출 때까지 대기
        CalculateYutResult();
        MovePlayer();
    }

    private void CalculateYutResult()
    {
        // 윷의 결과에 따라 이동 칸수 결정
        int frontCount = yutController.GetFrontCount(); // 앞면의 개수 가져오기

        switch (frontCount)
        {
            case 0:
                stepsToMove = 4; // 윷
                break;
            case 1:
                stepsToMove = 1; // 도
                break;
            case 2:
                stepsToMove = 2; // 개
                break;
            case 3:
                stepsToMove = 3; // 걸
                break;
            case 4:
                stepsToMove = 5; // 모
                break;
            default:
                stepsToMove = 0; // 잘못된 경우
                break;
        }

        Debug.Log("이동할 칸 수: " + stepsToMove);
    }

    private void MovePlayer()
    {
        // 현재 플레이어의 위치 업데이트
        currentPlayerPosition += stepsToMove;

        // 위치가 보드의 범위를 초과하면 루프하도록 설정
        if (currentPlayerPosition >= boardPositions.Count)
        {
            currentPlayerPosition %= boardPositions.Count;
        }

        // 플레이어의 현재 위치를 갱신
        UpdatePlayerPosition();
    }

    private void UpdatePlayerPosition()
    {
        // 현재 위치에 따라 게임판에서 플레이어를 표시합니다.
        Debug.Log("현재 플레이어 위치: " + currentPlayerPosition);
        // 이곳에서 실제로 플레이어의 위치를 표시할 수 있도록 추가 코드 작성
        // 예: 특정 게임 오브젝트의 위치를 업데이트하는 코드
        // playerGameObject.transform.position = boardPositions[currentPlayerPosition].position;
    }
}