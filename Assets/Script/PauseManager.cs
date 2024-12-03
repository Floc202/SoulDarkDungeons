using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Script
{
    public class PauseManager : MonoBehaviour
    {
        public static bool GameIsPaused = false;

        // Đối tượng UI để hiển thị menu Pause
        public GameObject pauseMenuUI;

        void Update()
        {
            // Kiểm tra nếu người chơi nhấn phím Escape
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        // Hàm để tiếp tục game
        public void Resume()
        {
            pauseMenuUI.SetActive(false); // Ẩn menu Pause
            Time.timeScale = 1f; // Tiếp tục thời gian
            GameIsPaused = false;
        }

        // Hàm để dừng game
        void Pause()
        {
            pauseMenuUI.SetActive(true); // Hiển thị menu Pause
            Time.timeScale = 0f; // Dừng thời gian
            GameIsPaused = true;
        }

        // Hàm để thoát game (nếu có nút thoát trong menu)
        public void QuitGame()
        {
            Debug.Log("Quitting game...");
            //Application.Quit(); // Thoát game
            Time.timeScale = 1; // Khôi phục thời gian
            SceneManager.LoadScene(0); // Thay đổi màn hình chính (nếu có)

        }
    }
}
