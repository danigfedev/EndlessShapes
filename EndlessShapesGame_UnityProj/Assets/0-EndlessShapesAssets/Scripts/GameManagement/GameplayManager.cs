using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GameManagement
{
    public class GameplayManager : MonoBehaviour
    {
        [Header("Ground speed tests")]
        public bool TestingSpeed = false;
        public float TestSpeed = 50;

        [Header("UI panels")]
        public GameObject menuPanel;
        public GameObject gamePanel;
        
        [Space(10)]
        public TextMeshProUGUI testScore;


        private float distance = 0;

        //Game State Management
        public GameProgressionData gameplayData;
        //private GameStates gameState;
        /*
        public delegate void OnGameStateChangeDelegate();
        public event OnGameStateChangeDelegate OnGameStateChangeEvent;
        public GameStates GameState
        {
            get { return gameState; }
            set
            {
                if (gameState == value) return;
                gameState = value;
                if (OnGameStateChangeEvent != null)
                    OnGameStateChangeEvent();
                Debug.LogWarning("Game State Changed to " + gameState.ToString());
            }
        }
        */

        public GroundSettings groundSettings;

        private void Awake()
        {
            //groundSettings.currentGroundSpeed = groundSpeed;
            groundSettings.ResetCurrentSpeed();
        }

        void Start()
        {
            OnGameStateChange(GameStates.MENU);
        }

        int frameStep = 3;
        int frameCount = 1;
        void Update()
        {
            //TESTING State change === TO BE DELETED
            if (Input.GetKeyUp(KeyCode.Space))
                gameplayData.currentState = GameStates.MENU;

            if (frameCount < frameStep)
            {
                frameCount++;
                return;
            }
            frameCount = 1;

            //Speed tests
            if (TestingSpeed)
                ChangeSpeed(TestSpeed, 0);


            if (gameplayData.currentState == GameStates.PLAYING)
            {
                //NOTE: If i wanted to calculate distance gradually (matching ground tile velocity lerping),
                //That lerp process should be done here!
                distance += groundSettings.CurrentGroundSpeed * Time.deltaTime;
                testScore.text = ((int)distance).ToString();
            }
        }

        public void OnGameStateChange(GameStates newState)
        {
            gameplayData.currentState = newState;

            Debug.Log("[GameManagement] Game State changed to " + gameplayData.currentState.ToString());
            switch (gameplayData.currentState)
            {
                case GameStates.MENU:
                    ShowUIMenu(menuPanel);
                    ChangeSpeed(groundSettings.idleSpeed, 2);
                    break;
                case GameStates.PLAYING:
                    Debug.LogWarning("YAAAAY I'm playing");
                    //Testing functionality
                    ChangeSpeed(groundSettings.gameplaySpeedList[0].speedValue, 2);
                    break;
                case GameStates.PAUSE:
                    break;
                case GameStates.GAME_OVER:
                    break;
            }
        }

        private void ShowUIMenu(GameObject menu)
        {
            if (!menu)
                return;
            Transform parentCanvas = menu.transform.parent;
            foreach (Transform ui_menu in parentCanvas)
                ui_menu.gameObject.SetActive(false);

            menu.SetActive(true);
        }


        Coroutine speedChangeCoroutine; //Storing a coroutine reference to control whther 
        //a speed change process is in progress.
        private void ChangeSpeed(float newSpeed, float transitionDuration)
        {
            if (transitionDuration <= 0)
            {
                groundSettings.CurrentGroundSpeed = newSpeed;
                return;
            }

            if (speedChangeCoroutine != null)
                StopCoroutine(speedChangeCoroutine);
            speedChangeCoroutine = StartCoroutine(ChangeSpeedCoroutine(newSpeed, transitionDuration));
        }

        /// <summary>
        /// Changes ground speed gradually to reach value given as argument
        /// NOTE: Coroutine returns on FixedUpdate (as this is a Physics calculation)
        /// </summary>
        /// <param name="newSpeed"></param>
        /// <param name="transitionTime"></param>
        /// <returns></returns>
        public IEnumerator ChangeSpeedCoroutine(float newSpeed, float transitionTime)
        {
            float timeFactor = 0;
            float initialSpeed = groundSettings.CurrentGroundSpeed;
            while (groundSettings.CurrentGroundSpeed < newSpeed)
            {
                groundSettings.CurrentGroundSpeed = Mathf.Lerp(initialSpeed, newSpeed, timeFactor);
                yield return new WaitForFixedUpdate();
                timeFactor += Time.fixedDeltaTime / transitionTime;
            }
            speedChangeCoroutine = null;
        }
    }
}