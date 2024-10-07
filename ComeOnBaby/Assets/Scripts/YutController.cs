using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YutController : MonoBehaviour
{
    public float bounceHeight = 2f; // ƨ��� ����
    public float bounceDuration = 0.5f; // ƨ��� �ð�
    private bool isBouncing = false;

    // �ؽ�ó�� ���� ����
    public Material frontMaterial; // �ո� ����
    public Material backMaterial; // �޸� ����

    // ���� �ո�� �޸� ���¸� ����
    private int frontCount = 0; // �ո��� ����

    private void Start()
    {
        UpdateMaterial();
    }

    public void Bounce()
    {
        if (!isBouncing)
        {
            frontCount = 0; // ���� ������ �ʱ�ȭ
            StartCoroutine(BounceCoroutine());
        }
    }

    private IEnumerator BounceCoroutine()
    {
        isBouncing = true;
        Vector3 originalPosition = transform.position;
        Vector3 targetPosition = originalPosition + Vector3.up * bounceHeight;

        // �ּ� �� ���� ȸ��
        float totalRotationAngle = 360f; // 1 ����
        float elapsedTime = 0f;

        // ���� ƨ���
        while (elapsedTime < bounceDuration)
        {
            float t = elapsedTime / bounceDuration;
            transform.position = Vector3.Lerp(originalPosition, targetPosition, t);
            transform.Rotate(0, 0, totalRotationAngle * Time.deltaTime / bounceDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // �Ʒ��� ��������
        elapsedTime = 0f;
        while (elapsedTime < bounceDuration)
        {
            float t = elapsedTime / bounceDuration;
            transform.position = Vector3.Lerp(targetPosition, originalPosition, t);
            transform.Rotate(0, 0, totalRotationAngle * Time.deltaTime / bounceDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // �ٴڿ� ���� �� ���� ���� Ȯ��
        UpdateMaterialBasedOnRotation();

        // ����� ���
        Debug.Log("���� �� ���¸� Ȯ���մϴ�."); // ���� �� ���� Ȯ�� �޽���

        isBouncing = false;
    }

    private void UpdateMaterialBasedOnRotation()
    {
        // ������Ʈ�� ���� ���ϴ��� �Ǵ�
        if (transform.up.y > 0) // Y���� ������ ���ϰ� �ִٸ�
        {
            GetComponent<Renderer>().material = frontMaterial; // �ո� ����
            frontCount++; // �ո� ī��Ʈ ����
            Debug.Log("�ո��� ���� ���ϰ� �ֽ��ϴ�."); // ����� ���
        }
        else
        {
            GetComponent<Renderer>().material = backMaterial; // �޸� ����
            Debug.Log("�޸��� ���� ���ϰ� �ֽ��ϴ�."); // ����� ���
        }
    }

    // �ո��� ������ ��ȯ�ϴ� �޼���
    public int GetFrontCount()
    {
        return frontCount;
    }

    private void UpdateMaterial()
    {
        // �ʱ� ���¿��� ���� ����
        UpdateMaterialBasedOnRotation();
    }
}
