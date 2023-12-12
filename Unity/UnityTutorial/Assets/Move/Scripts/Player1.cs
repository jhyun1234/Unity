using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public Vector3 direction;

    public float speed = 5f;

    
    void Update()
    {
        // Input.GetAxis() : Ư���� Key�� ���� �� -1 ~ 1 ������ ���� ��ȯ�ϴ� �Լ��̴�.
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        // Time.deltatime : ���� �������� �Ϸ�Ǵ� ������ �ɸ� �ð��� �ǹ��Ѵ�.
        
        transform.position += direction * speed * Time.deltaTime;
    }
}
