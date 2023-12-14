using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player1 : MonoBehaviour
{
    public Vector3 direction;

    public float speed = 5f;
    public Camera playerCamera;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        // Input.GetAxis() : 특정한 Key를 누를 때 -1 ~ 1 사이의 값을 반환하는 함수이다.
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        // Time.deltatime : 이전 프레임이 완료되는 데까지 걸린 시간을 의미한다.
        
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.buildIndex !=0)
        {
            playerCamera.gameObject.SetActive(true);
        }
        else
        {
            playerCamera.gameObject.SetActive(false);
        }
        
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
