using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Script
{
    
    public class GameOverManager : MonoBehaviour
    {
        public GameObject gameOverCanvas; // Biến tham chiếu tới GameOverCanvas

        private void Start()
        {
            gameOverCanvas.SetActive(false); // Ẩn canvas khi game bắt đầu
        }

        public void GameOver()
        {
            gameOverCanvas.SetActive(true); // Hiển thị canvas khi game over
            Time.timeScale = 0; // Dừng thời gian trong game
        }

        public void RestartGame()
        {
            Time.timeScale = 1; // Khôi phục thời gian
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Tải lại màn chơi hiện tại
        }

        public void ReturnToMainMenu()
        {
            Time.timeScale = 1; // Khôi phục thời gian
            SceneManager.LoadScene(0); // Thay đổi màn hình chính (nếu có)
        }

    }
}
