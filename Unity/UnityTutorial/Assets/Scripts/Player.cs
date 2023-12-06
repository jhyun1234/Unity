using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Hp = 100;
    private int Speed = 5;
    public void Start()
    {
        Debug.Log("Hp : "+Hp);
    }

    
}
