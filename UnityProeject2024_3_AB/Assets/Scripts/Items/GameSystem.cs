using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace STORYGAME
{

#if UNITY_EDITOR
    [CustomEditor(typeof(GameSystem))]                  //전처리기 유니티 에디터에서만 동작
    public class GameSystemEditer : Editor              //에디터를 상속받는 클래스 생성
    {
        public override void OnInspectorGUI()           //유니티의 인스펙터 함수를 재정의
        {
            base.OnInspectorGUI();
            GameSystem gameSystem = (GameSystem)target;//유니티 인스펙터 함수 동작을 같이 한다.(Base)

            if (GUILayout.Button("Reset Story Modes"))
            {
                gameSystem.ResetStoryModels();
            }
        }
    }
#endif
    public class GameSystem : MonoBehaviour
    {
        public static GameSystem instance;          //간단한 싱글톤 화

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
            storyModels = Resources.LoadAll<StoryTableObject>("");      //Resources 폴더 아래 모든 StoryModel을 불러 오기
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
