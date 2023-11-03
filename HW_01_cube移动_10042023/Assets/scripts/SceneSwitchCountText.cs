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

        // ����MySceneManager���¼����ڳ����л�ʱ����Text
        mySceneManager.OnSceneSwitchCountChanged += UpdateText;
    }

    private void UpdateText()
    {
        text.text = "SceneSwitchCount: " + mySceneManager.GetSceneSwitchCount().ToString();
    }

    private void OnDestroy()
    {
        // �ڶ�������ʱȡ�������¼����Է�ֹ�ڴ�й©
        mySceneManager.OnSceneSwitchCountChanged -= UpdateText;
    }
}
