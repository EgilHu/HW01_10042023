using UnityEngine;
using UnityEngine.UI;
using MyNamespace;
using TMPro;

public class SceneSwitchCountText : MonoBehaviour
{
    public TextMeshProUGUI text;
    private MySceneManager mySceneManager;

    private void Start()
    {
        mySceneManager = MySceneManager.Instance;

        UpdateText();

        // 订阅MySceneManager的事件以在场景切换时更新Text
        mySceneManager.OnSceneSwitchCountChanged += UpdateText;
    }

    private void UpdateText()
    {
        text.text = "SceneSwitchCount: " + mySceneManager.GetSceneSwitchCount().ToString();
    }

    private void OnDestroy()
    {
        // 在对象销毁时取消订阅事件，以防止内存泄漏
        mySceneManager.OnSceneSwitchCountChanged -= UpdateText;
    }
}
