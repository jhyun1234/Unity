using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject unit;
    [SerializeField] Factory factory;

    [SerializeField] int activeCount = 0;
    [SerializeField] int creatCount = 5;
    [SerializeField] List<GameObject> unitList;

    public static ObjectPool instance;

    public void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    void Start()
    {
        unitList.Capacity = 20;
        Unit1();
        
        
    }
    public void Unit1()
    {
        for(int i=0; i<5; i++)
        {
            // 1. 게임 오브젝트를 생성  
            // GameObject obj = factory.CreateUnit(unit);
            GameObject obj = Instantiate(unit);

            // 2. 게임 오브젝트를 비활성화 한다.
            obj.SetActive(false);

            // 2. List에 게임 오브젝트를 넣어준다.
            unitList.Add(obj);
        }
    }

    public GameObject GameObject()
    {
        // 1. activeCount 변수의 값을 증가시킨다.
        activeCount = activeCount++ % unitList.Count;

        // 2. activeCount 인덱스로 접근한 게임 오브젝트 비활성화되어 있는지 확인한다
        if (unitList[activeCount].activeSelf==false)
        {
            // 3. activeCount 인덱스로 접근한 게임 오브젝트가 비활성화되어있다면 활성화 시킨다.
            GameObject obj = unitList[activeCount++];

            obj.gameObject.SetActive(true);

            // 4. activeCount 인덱스로 접근한 게임 오브젝트를 반환한다.
            return obj;
        }

        return null;
    }
    
    void Update()
    {
        
    }
}
