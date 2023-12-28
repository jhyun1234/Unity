using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] int selectCount;
    [SerializeField] List<GameObject> characterList;
    void Start()
    {
        characterList.Capacity = 5;
        ShowCharacter();
    }

    private void ShowCharacter()
    {
        for(int i=0; i<characterList.Count; i++)
        {
            characterList[i].SetActive(false);
        }

        characterList[selectCount].SetActive(true);
    }
    
}
