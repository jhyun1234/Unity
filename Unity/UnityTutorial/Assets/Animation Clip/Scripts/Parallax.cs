using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    [SerializeField] Rect rect; //SerializeField : private 변수를 인스펙터에 노출 시킬 수 있게 할 수 있다.
    [SerializeField] RawImage rawImage;

    [SerializeField] float speed = 0.25f;

    
    void Update()
    {
        rect = rawImage.uvRect;
        rect.x += Time.deltaTime * speed;

        rawImage.uvRect = rect;
    }
}
