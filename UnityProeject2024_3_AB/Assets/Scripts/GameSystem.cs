using STORYGAME;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
[CustomEditor(typeof(GameSystem))]
public class GameSystemEdit : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GameSystem gameSystem = (GameSystem)target;

        if (GUILayout.Button("Reset Story Modes"))
        {
            gameSystem.ResetStoryModels();
        }
    }
}
#endif

public class GameSystem : MonoBehaviour
{
    public static GameSystem instance;

    private void Awake()
    {
        instance = this;
    }

    public enum GAMESTAGE
    {
        STORYSHOW,
        WAITSELECT,
        STORYEND
    }

    public Stats stats;
    public GAMESTAGE currentState;
    public int currentStoryIndex = 1;
    public StoryModel[] storyModels;


#if UNITY_EDITOR
    /// <summary>
    /// Resources폴더 아래 모든 StoryModels을 불러오는 함수
    /// </summary>
    [ContextMenu("Reset Story Models")]
    public void ResetStoryModels()
    {
        storyModels = Resources.LoadAll<StoryModel>("");    
    }
#endif

    /// <summary>
    /// 스토리 모델 번호를 넘겨주고 내부에서 서치
    /// </summary>
    /// <param name="number">스토리 넘버 입력</param>
    public void StoryShow(int number)
    {
        StoryModel tempStoryModels = FIndStoryModel(number);

        //StorySystem.Instance.currentStoryModel = tempStoryModels;
        //StorySystem.Instance.CoShowText();
    }

    StoryModel FIndStoryModel(int number)
    {
        StoryModel tempStoryModels = null;
        for (int i = 0; i < storyModels.Length; i++)// for문으로 StoryModel 을 검색하여 Number와 같은 스토리 번호로 스토리 모델을 찾아 반환한다
        {
            if (storyModels[i].storyNumber == number)
            {
                tempStoryModels = storyModels[i];
                break;
            }
        }
        return tempStoryModels;
    }
    /// <summary>
    /// 매인 스토리중 랜덤한 스토리를 반환해주는 함수
    /// </summary>
    /// <returns></returns>
    StoryModel RandomStory()
    {
        StoryModel tempStoryModels = null;

        List<StoryModel> storyModelList = new List<StoryModel>();
        for (int i = 0; i < storyModels.Length; i++)// for문으로 StoryModel 을 검색하여 Number와 같은 스토리 번호로 스토리 모델을 찾아 반환한다
        {
            if (storyModels[i].storyType == StoryModel.STORYTYPE.MAIN)
            {
                storyModelList.Add(storyModels[i]);
            }
        }

        tempStoryModels = storyModelList[Random.Range(0, storyModelList.Count)];
        currentStoryIndex = tempStoryModels.storyNumber;
        return tempStoryModels;
    }
}
