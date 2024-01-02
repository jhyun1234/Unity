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
            // 1. ���� ������Ʈ�� ����  
            // GameObject obj = factory.CreateUnit(unit);
            GameObject obj = Instantiate(unit);

            // 2. ���� ������Ʈ�� ��Ȱ��ȭ �Ѵ�.
            obj.SetActive(false);

            // 2. List�� ���� ������Ʈ�� �־��ش�.
            unitList.Add(obj);
        }
    }

    public GameObject GameObject()
    {
        // 1. activeCount ������ ���� ������Ų��.
        activeCount = activeCount++ % unitList.Count;

        // 2. activeCount �ε����� ������ ���� ������Ʈ ��Ȱ��ȭ�Ǿ� �ִ��� Ȯ���Ѵ�
        if (unitList[activeCount].activeSelf==false)
        {
            // 3. activeCount �ε����� ������ ���� ������Ʈ�� ��Ȱ��ȭ�Ǿ��ִٸ� Ȱ��ȭ ��Ų��.
            GameObject obj = unitList[activeCount++];

            obj.gameObject.SetActive(true);

            // 4. activeCount �ε����� ������ ���� ������Ʈ�� ��ȯ�Ѵ�.
            return obj;
        }

        return null;
    }
    
    void Update()
    {
        
    }
}
