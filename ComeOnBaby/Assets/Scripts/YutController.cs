using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YutController : MonoBehaviour
{
    public Rigidbody[] yutRigidbodies;
    public float throwForce = 5f;
    public Vector3 throwDirection;   // Vector3로 선언

    void Start()
    {
        // 던질 때의 방향을 설정, 윗방향으로 튕기기
        throwDirection = Vector3.up;
    }

    public void ThrowYut()
    {
        foreach (Rigidbody yutRb in yutRigidbodies)
        {
            // 위로 향하는 방향으로 랜덤한 힘을 가함
            Vector3 force = (throwDirection + Random.insideUnitSphere * 0.5f).normalized * throwForce;
            yutRb.AddForce(force, ForceMode.Impulse);

            // 윷이 회전하도록 토크 추가
            Vector3 torque = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            yutRb.AddTorque(torque * throwForce, ForceMode.Impulse);
        }
    }

    public void CheckYutResult()
    {
        foreach (Rigidbody yutRb in yutRigidbodies)
        {
            Vector3 upVector = yutRb.transform.up;

            // 윷이 어느 방향으로 떨어졌는지 확인 (Up 벡터가 얼마나 위를 향하는지에 따라 판별)
            if (Vector3.Dot(upVector, Vector3.up) > 0)
            {
                Debug.Log("앞면!");
            }
            else
            {
                Debug.Log("뒷면!");
            }
        }
    }
}