using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YutController : MonoBehaviour
{
    public Rigidbody[] yutRigidbodies;
    public float throwForce = 5f;
    public Vector3 throwDirection;   // Vector3�� ����

    void Start()
    {
        // ���� ���� ������ ����, ���������� ƨ���
        throwDirection = Vector3.up;
    }

    public void ThrowYut()
    {
        foreach (Rigidbody yutRb in yutRigidbodies)
        {
            // ���� ���ϴ� �������� ������ ���� ����
            Vector3 force = (throwDirection + Random.insideUnitSphere * 0.5f).normalized * throwForce;
            yutRb.AddForce(force, ForceMode.Impulse);

            // ���� ȸ���ϵ��� ��ũ �߰�
            Vector3 torque = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            yutRb.AddTorque(torque * throwForce, ForceMode.Impulse);
        }
    }

    public void CheckYutResult()
    {
        foreach (Rigidbody yutRb in yutRigidbodies)
        {
            Vector3 upVector = yutRb.transform.up;

            // ���� ��� �������� ���������� Ȯ�� (Up ���Ͱ� �󸶳� ���� ���ϴ����� ���� �Ǻ�)
            if (Vector3.Dot(upVector, Vector3.up) > 0)
            {
                Debug.Log("�ո�!");
            }
            else
            {
                Debug.Log("�޸�!");
            }
        }
    }
}