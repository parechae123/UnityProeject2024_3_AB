using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExCharacterManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<ExCharacter> CharacterList = new List<ExCharacter>();
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < CharacterList.Count; i++)
            {
                CharacterList[i].DestroyCharacter();
            }
        }
    }
}
