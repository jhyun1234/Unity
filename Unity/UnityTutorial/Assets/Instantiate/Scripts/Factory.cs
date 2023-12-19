using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] Transform spawnPosition;



    // Unit -> 소서리스,마법사,오크,전사 코드 수정이 일어나지 않는다
    public GameObject CreateUnit(Unit unit)
    {
        // 게임 오브젝트 생성
        GameObject monster = Instantiate(unit.gameObject, spawnPosition);

        // 게임 오브젝트를 반환
        return monster;
    }

}
