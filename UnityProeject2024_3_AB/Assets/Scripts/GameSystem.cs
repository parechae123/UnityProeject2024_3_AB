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
    /// Resources���� �Ʒ� ��� StoryModels�� �ҷ����� �Լ�
    /// </summary>
    [ContextMenu("Reset Story Models")]
    public void ResetStoryModels()
    {
        storyModels = Resources.LoadAll<StoryModel>("");    
    }
#endif

    /// <summary>
    /// ���丮 �� ��ȣ�� �Ѱ��ְ� ���ο��� ��ġ
    /// </summary>
    /// <param name="number">���丮 �ѹ� �Է�</param>
    public void StoryShow(int number)
    {
        StoryModel tempStoryModels = FIndStoryModel(number);

        //StorySystem.Instance.currentStoryModel = tempStoryModels;
        //StorySystem.Instance.CoShowText();
    }

    StoryModel FIndStoryModel(int number)
    {
        StoryModel tempStoryModels = null;
        for (int i = 0; i < storyModels.Length; i++)// for������ StoryModel �� �˻��Ͽ� Number�� ���� ���丮 ��ȣ�� ���丮 ���� ã�� ��ȯ�Ѵ�
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
    /// ���� ���丮�� ������ ���丮�� ��ȯ���ִ� �Լ�
    /// </summary>
    /// <returns></returns>
    StoryModel RandomStory()
    {
        StoryModel tempStoryModels = null;

        List<StoryModel> storyModelList = new List<StoryModel>();
        for (int i = 0; i < storyModels.Length; i++)// for������ StoryModel �� �˻��Ͽ� Number�� ���� ���丮 ��ȣ�� ���丮 ���� ã�� ��ȯ�Ѵ�
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
