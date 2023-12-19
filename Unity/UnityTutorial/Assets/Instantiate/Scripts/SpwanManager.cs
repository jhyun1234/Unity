using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanManager : MonoBehaviour
{
    // [0]   [1]
    // �Ҽ� ������
    [SerializeField] List<Unit> listUnits;

    [SerializeField] Factory factory;

    
    
    private void Start()
    {
        // StartCoroutine �ڷ�ƾ�� ����Ҷ� ����ؾ��Ѵ�
        StartCoroutine(CreateRoutine());
        Debug.Log("First");
    }
    
    public IEnumerator CreateRoutine()
    {
        while(true)
        {
            // Random.Range : 0 ~ �ִ�-1�� ���� ��ȯ�ϴ� �Լ��̴�.
            // Random.Range(0, listUnits.Count)  
            factory.CreateUnit(listUnits[Random.Range(0, listUnits.Count)]);

          // new WaitForSeconds(5f) : Ư���� �ð����� �ڷ�ƾ�� ����Ѵ�.
         yield return new WaitForSeconds(5f);

        }
    }

    
    
   


}
