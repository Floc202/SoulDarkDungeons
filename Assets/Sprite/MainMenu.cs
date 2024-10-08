using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Nhớ thêm thư viện này để làm việc với UI

public class MainMenu : MonoBehaviour
{
    public Image panel; // Kéo thả Panel vào đây trong Inspector
    public Text titleText; // Kéo thả Text tiêu đề vào đây
    public Button startButton; // Kéo thả Button vào đây

    // Start is called before the first frame update
    void Start()
    {
        // Thiết lập màu sắc cho Panel
        panel.color = new Color(0.1f, 0.1f, 0.4f, 1f); // Màu xanh đậm

        // Thiết lập màu sắc cho Text tiêu đề
        titleText.color = Color.white; // Màu trắng

        // Thiết lập màu sắc cho Button
        ColorBlock buttonColors = startButton.colors;
        buttonColors.normalColor = Color.green; // Màu xanh khi không chọn
        buttonColors.highlightedColor = Color.yellow; // Màu vàng khi hover
        buttonColors.pressedColor = Color.red; // Màu đỏ khi nhấn
        startButton.colors = buttonColors;
    }
}
