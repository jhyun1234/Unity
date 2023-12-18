using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanManager : MonoBehaviour
{
    [SerializeField] GameObject unit;
    [SerializeField] Transform createPosition;

    [Tooltip("몬스터를 생성하는 변수")]
    [SerializeField] int createCount = 5;
    private void Start()
    {
        
        // Instantiate : 게임 오브젝트를 생성하는 함수이다.
        for(int i=0; i< createCount; i++)
        {
            // 1. 게임 오브젝트 생성
            GameObject monster = Instantiate(unit, createPosition);

            // 2. 생성된 게임 오브젝트의 위치를 설정
            monster.transform.position = new Vector3(i*5, 0, createPosition.position.z);

            Debug.Log("Worle Position : " + monster.transform.position);
            Debug.Log("Local Position : " + monster.transform.localPosition);


        }
    }



}
