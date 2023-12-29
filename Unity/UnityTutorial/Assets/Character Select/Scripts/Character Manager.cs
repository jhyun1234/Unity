using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    
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
        
        characterList[DataManager.instance.SelectCount].SetActive(true);
    }
    
    public void OnLeftButton()
    {
        DataManager.instance.SelectCount--;
        if(DataManager.instance.SelectCount < 0)
        {
            DataManager.instance.SelectCount = characterList.Count - 1;
        }

        ShowCharacter();
    }

    public void OnRightButton()
    {
        DataManager.instance.SelectCount++;
        if (DataManager.instance.SelectCount >= characterList.Count)
        {
            DataManager.instance.SelectCount = 0;
        }
        ShowCharacter();
    }
}
