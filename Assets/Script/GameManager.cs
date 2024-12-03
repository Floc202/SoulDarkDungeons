using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Script
{
    public class GameManager : MonoBehaviour
    {
        public GameObject gameOverCanvas; // Canvas hiển thị Game Over
        public GameObject pauseMenuUI; // Canvas hiển thị menu Pause
        public static bool GameIsPaused = false;
        public bool isGameOver = false;

        private void Start()
        {
            gameOverCanvas.SetActive(false); // Ẩn canvas Game Over khi bắt đầu
            pauseMenuUI.SetActive(false); // Ẩn menu Pause khi bắt đầu
        }

        private void Update()
        {
            // Kiểm tra nếu người chơi nhấn phím Escape để kích hoạt Pause
            if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver)
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

        public void GameOver()
        {
            isGameOver = true;
            gameOverCanvas.SetActive(true); // Hiển thị canvas Game Over
            pauseMenuUI.SetActive(false); // Đảm bảo menu Pause ẩn khi Game Over
            Time.timeScale = 0; // Dừng thời gian
        }

        public void RestartGame()
        {
            isGameOver = false;
            Time.timeScale = 1; // Khôi phục thời gian
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Tải lại màn chơi hiện tại
        }

        public void ReturnToMainMenu()
        {
            isGameOver = false;
            Time.timeScale = 1; // Khôi phục thời gian
            SceneManager.LoadScene(0); // Tải về màn hình chính
        }

        public void Resume()
        {
            if (!isGameOver)
            {
                pauseMenuUI.SetActive(false); // Ẩn menu Pause
                Time.timeScale = 1f; // Tiếp tục thời gian
                GameIsPaused = false;
            }
        }

        public void Pause()
        {
            if (!isGameOver)
            {
                pauseMenuUI.SetActive(true); // Hiển thị menu Pause
                Time.timeScale = 0f; // Dừng thời gian
                GameIsPaused = true;
            }
        }

        public void QuitGame()
        {
            Debug.Log("Quitting game...");
            Time.timeScale = 1; // Khôi phục thời gian trước khi thoát
            SceneManager.LoadScene(0); // Về màn hình chính
        }
    }
}
