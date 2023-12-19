using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] Transform spawnPosition;



    // Unit -> �Ҽ�����,������,��ũ,���� �ڵ� ������ �Ͼ�� �ʴ´�
    public GameObject CreateUnit(Unit unit)
    {
        // ���� ������Ʈ ����
        GameObject monster = Instantiate(unit.gameObject, spawnPosition);

        // ���� ������Ʈ�� ��ȯ
        return monster;
    }

}
