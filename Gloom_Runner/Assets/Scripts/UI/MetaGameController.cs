using System.Collections;
using System.Collections.Generic;
using Platformer.Mechanics;
using Platformer.UI;
using UnityEngine;
using Cinemachine;


namespace Platformer.UI
{
    /// <summary>
    /// The MetaGameController is responsible for switching control between the high level
    /// contexts of the application, eg the Main Menu and Gameplay systems.
    /// </summary>
    [System.Serializable]
    public class MetaGameController : MonoBehaviour
    {
        /// <summary>
        /// The main UI object which used for the Pause Menu.
        /// </summary>
        public MainUIController mainMenu;

        [SerializeField] GameObject Nul;
        [SerializeField] GameObject Peng;
        [SerializeField] GameObject Mas;
        public CinemachineVirtualCamera vcam;

        /// <summary>
        /// The main UI object which used for the Main Menu.
        /// </summary>
        public MainUIController victoryMenu;
        public MainUIController defeatMenu;

        public float test;

        private void Awake()
        {
            if (PlayerPrefs.GetInt("_character_") == 0)
            {
                Nul.gameObject.SetActive(true);
                vcam.Follow = Nul.transform;
            }
            if (PlayerPrefs.GetInt("_character_") == 1)
            {
                Peng.gameObject.SetActive(true);
                vcam.Follow = Peng.transform;
            }
            if (PlayerPrefs.GetInt("_character_") == 2)
            {
                Mas.gameObject.SetActive(true);
                vcam.Follow = Mas.transform;
            }
        }

        /// <summary>
        /// A list of canvas objects which are used during gameplay (when the main ui is turned off)
        /// </summary>
        ///public Canvas[] gamePlayCanvasii;

        /// <summary>
        /// The game controller.
        /// </summary>
        public GameController gameController;

        bool showMainCanvas = false;
        bool showVictoryCanvas = false;
        bool showDefeatCanvas = false;

        void OnEnable()
        {
            _ToggleMainMenu(showMainCanvas);
        }

        /// <summary>
        /// Turn the main menu on or off.
        /// </summary>
        /// <param name="show"></param>
        public void ToggleMainMenu(bool show)
        {
            if (this.showMainCanvas != show && this.showVictoryCanvas == false)
            {
                _ToggleMainMenu(show);
            }
        }

        void _ToggleMainMenu(bool show)
        {
            if (show)
            {
                Time.timeScale = 0;
                mainMenu.gameObject.SetActive(true);
                ///foreach (var i in gamePlayCanvasii) i.gameObject.SetActive(false);
            }
            else
            {
                Time.timeScale = 1;
                mainMenu.gameObject.SetActive(false);
                ///foreach (var i in gamePlayCanvasii) i.gameObject.SetActive(true);
            }
            this.showMainCanvas = show;
        }

        public void ToggleVictoryMenu(bool show)
        {
            if (this.showVictoryCanvas != show)
            {
                _ToggleVictoryMenu(show);
            }
        }

        public void ToggleDefeatMenu(bool show)
        {
            if (this.showDefeatCanvas != show)
            {
                _ToggleDefeatMenu(show);
            }
        }

        void _ToggleVictoryMenu(bool show)
        {
            if (show)
            {
                Time.timeScale = 0;
                victoryMenu.gameObject.SetActive(true);
                ///foreach (var i in gamePlayCanvasii) i.gameObject.SetActive(false);
            }
            else
            {
                Time.timeScale = 1;
                victoryMenu.gameObject.SetActive(false);
                ///foreach (var i in gamePlayCanvasii) i.gameObject.SetActive(true);
            }
            this.showVictoryCanvas = show;
        }

        void _ToggleDefeatMenu(bool show)
        {
            if (show)
            {
                Time.timeScale = 0;
                defeatMenu.gameObject.SetActive(true);
                ///foreach (var i in gamePlayCanvasii) i.gameObject.SetActive(false);
            }
            else
            {
                Time.timeScale = 1;
                defeatMenu.gameObject.SetActive(false);
                ///foreach (var i in gamePlayCanvasii) i.gameObject.SetActive(true);
            }
            this.showDefeatCanvas = show;
        }

        void Update()
        {
            if (Input.GetButtonDown("Menu"))
            {
                ToggleMainMenu(show: !showMainCanvas);
            }
        }

    }
}