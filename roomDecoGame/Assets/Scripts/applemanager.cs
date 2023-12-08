using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
#if UNITY_EDITOR
using UnityEditor.PackageManager;
#endif
using UnityEngine.SceneManagement;

public class applemanager : MonoBehaviour
{
    private const string mainScene = "SampleScene";
    [SerializeField] private GameObject applePrefab; // ��� ������
    [SerializeField] private GameObject basket; // �ٱ���
    [SerializeField] private int score = 0; // ����
    [SerializeField] private float missscore; // ��ģ ����
    [SerializeField] private float time;
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject ready_panel;
    [SerializeField] private GameObject result_panel;
    [SerializeField] private TextMeshProUGUI count_text; // ī��Ʈ�ٿ�
    [SerializeField] private TextMeshProUGUI score_text; // ����
    [SerializeField] private TextMeshProUGUI result_text; // ����
    //[SerializeField] private TextMeshProUGUI miss_text; //��ģ ����
    //[SerializeField] private TextMeshProUGUI accuracy; //��Ȯ��
    //[SerializeField] private TextMeshProUGUI applecount; // ���� ��� ��
    //[SerializeField] private Slider timerSlider; //���� �ð�
    [SerializeField] private TextMeshProUGUI time_text; // ���� �ð�

    [SerializeField] private float duration = 60f; // ��� ���� �ð�
    [SerializeField] private int totalApples = 100; // ������ ����� �� ����
    [SerializeField] private List<Sprite> appleImages;
    private List<GameObject> apples = new List<GameObject>();


    void Start()
    {
        StartCoroutine(Ready());
    }

    public void OnClickBack()
    {
        SceneManager.LoadScene(mainScene);
    }

    IEnumerator Ready()
    {
        var canvasGroup = canvas.GetComponent<CanvasGroup>();
        int second = 3;
        canvasGroup.alpha = 0.1f;
        while (second > 0)
        {
            count_text.text = second.ToString();
            second--;
            yield return new WaitForSeconds(1.0f);
        }
        ready_panel.SetActive(false);
        canvasGroup.alpha = 1f;
        StartCoroutine(SpawnApples());
    }

    IEnumerator Finish()
    {
        while (apples.Count > 0)
        {
            yield return new WaitForSeconds(0.1f);
        }
        result_text.text = score_text.text + " ���� ����� �������ϴ�!";

        var canvasGroup = canvas.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0.1f;
        canvasGroup.interactable = false;
        basket.active = false;
        int coin = PlayerPrefs.GetInt("Coin", 0);
        PlayerPrefs.SetInt("Coin", coin + score);
        result_panel.SetActive(true);
    }

    IEnumerator SpawnApples()
    {
        

        result_panel.SetActive(false);
        // ���� ������ ����
        List<float> intervals = new List<float>();
        for (int i = 0; i < totalApples; i++)
        {
            intervals.Add(UnityEngine.Random.Range(-0.2f, 0.2f));
        }
        // ���� ������ �� ���
        float totalRandom = 0;
        foreach (float val in intervals)
        {
            totalRandom += val;
        }

        // ���� ���ݰ� �Բ� ��� ������ ���
        float averageInterval = (duration - totalRandom) / totalApples;

        // �����̴��� �ִ� �� ����
        //timerSlider.maxValue = duration;
        //timerSlider.value = duration;

        float elapsed = 0; // ��� �ð�

        for (int i = 0; i < totalApples; i++)
        {
            yield return new WaitForSeconds(averageInterval + intervals[i]); // ������ ���� + ��� ����

            GameObject apple = Instantiate(applePrefab);
            
            apple.transform.position = new Vector2(UnityEngine.Random.Range(-7.5f, 7.5f), UnityEngine.Random.Range(5.5f, 7f)); // ���� ��ġ
            Rigidbody2D appleRb = apple.AddComponent<Rigidbody2D>(); // Rigidbody2D ������Ʈ �߰�
            appleRb.gravityScale = UnityEngine.Random.Range(2f, 4f); // ���� �ӵ�

            // x�� �������� ������ �� �߰�
            appleRb.AddForce(new Vector2(UnityEngine.Random.Range(-1f, 1f), 0), ForceMode2D.Impulse);

            foreach (var existingApple in apples)
            {
                var appleComponent = apple.GetComponent<Collider2D>();
                if (appleComponent != null && existingApple != null)
                {
                    Physics2D.IgnoreCollision(appleComponent, existingApple.GetComponent<Collider2D>());
                }
            }
            apple.gameObject.GetComponent<SpriteRenderer>().sprite = appleImages[UnityEngine.Random.Range(0, 7)];   // ��� �̹��� ����
            apples.Add(apple);

            // ��� �ð� ������Ʈ
            elapsed += averageInterval + intervals[i];
            // �����̴� �� ������Ʈ
            //timerSlider.value = duration - elapsed;
            time = duration - elapsed;
            if(time >= 3)
            {
                time_text.text = ((int)time).ToString();
            }
            else if(time < 3 && time > 0)
            {
                time_text.text = (time).ToString("F3");
                time_text.color = Color.red;
            }
            else
            {
                time_text.text = "0";
                StartCoroutine(Finish());
                yield break;
            }
            
        }
        StartCoroutine(Finish());
    }


    public void DestroyApple(GameObject apple)
    {
        apples.Remove(apple); // ����� ����Ʈ���� ����
        Destroy(apple); // ����� �ı�
        //applecount.text = "���� ��� ��: " + (totalApples - (score + missscore)).ToString();
    }

    public void IncreaseScore()
    {
        score++;
        score_text.text = score.ToString();
        //accuracy.text = "��Ȯ��: " + (((score / (score + missscore)) * 100).ToString("F2")) + "%";

    }

    public void MissScore()
    {
        missscore++;
        //miss_text.text = "��ģ ��� ��: " + missscore.ToString();
    }
}
