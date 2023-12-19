using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanManager : MonoBehaviour
{
    // [0]   [1]
    // 소서 마법사
    [SerializeField] List<Unit> listUnits;

    [SerializeField] Factory factory;

    
    
    private void Start()
    {
        // StartCoroutine 코루틴을 사용할때 사용해야한다
        StartCoroutine(CreateRoutine());
        Debug.Log("First");
    }
    
    public IEnumerator CreateRoutine()
    {
        while(true)
        {
            // Random.Range : 0 ~ 최댓값-1의 값을 반환하는 함수이다.
            // Random.Range(0, listUnits.Count)  
            factory.CreateUnit(listUnits[Random.Range(0, listUnits.Count)]);

          // new WaitForSeconds(5f) : 특정한 시간동한 코루틴을 대기한다.
         yield return new WaitForSeconds(5f);

        }
    }

    
    
   


}
