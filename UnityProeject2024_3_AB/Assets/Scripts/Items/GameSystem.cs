using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace STORYGAME
{

#if UNITY_EDITOR
    [CustomEditor(typeof(GameSystem))]                  //��ó���� ����Ƽ �����Ϳ����� ����
    public class GameSystemEditer : Editor              //�����͸� ��ӹ޴� Ŭ���� ����
    {
        public override void OnInspectorGUI()           //����Ƽ�� �ν����� �Լ��� ������
        {
            base.OnInspectorGUI();
            GameSystem gameSystem = (GameSystem)target;//����Ƽ �ν����� �Լ� ������ ���� �Ѵ�.(Base)

            if (GUILayout.Button("Reset Story Modes"))
            {
                gameSystem.ResetStoryModels();
            }
        }
    }
#endif
    public class GameSystem : MonoBehaviour
    {
        public static GameSystem instance;          //������ �̱��� ȭ

        private void Awake()
        {
            instance = this;
        }
        public  enum GAMESTATE
        {
            STORYSHOW,
            WAITsELECT,
            STORYEND,
            BATTLEMODE,
            BATTLEDONE,
            SHOPMODE,
            ENDMODE
        }
        public GAMESTATE currentState;
        public StoryTableObject[] storyModels;
        public int currentStoryIndex = 1;
#if UNITY_EDITOR
        [ContextMenu("Reset Story Models")]
        public void ResetStoryModels()
        {
            storyModels = Resources.LoadAll<StoryTableObject>("");      //Resources ���� �Ʒ� ��� StoryModel�� �ҷ� ����
        }
#endif
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
