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
    private const string mainScene = "testScene";
    [SerializeField] private GameObject applePrefab; // 사과 프리팹
    [SerializeField] private GameObject basket; // 바구니
    [SerializeField] private int score = 0; // 점수
    [SerializeField] private float missscore; // 놓친 점수
    [SerializeField] private float time;
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject ready_panel;
    [SerializeField] private GameObject result_panel;
    [SerializeField] private TextMeshProUGUI count_text; // 카운트다운
    [SerializeField] private TextMeshProUGUI score_text; // 점수
    [SerializeField] private TextMeshProUGUI result_text; // 점수
    //[SerializeField] private TextMeshProUGUI miss_text; //놓친 점수
    //[SerializeField] private TextMeshProUGUI accuracy; //정확도
    //[SerializeField] private TextMeshProUGUI applecount; // 남은 사과 수
    //[SerializeField] private Slider timerSlider; //남은 시간
    [SerializeField] private TextMeshProUGUI time_text; // 남은 시간

    [SerializeField] private float duration = 60f; // 사과 생성 시간
    [SerializeField] private int totalApples = 100; // 생성할 사과의 총 개수
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
        result_text.text = score_text.text + " 점의 기록을 세웠습니다!";

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
        // 랜덤 간격을 생성
        List<float> intervals = new List<float>();
        for (int i = 0; i < totalApples; i++)
        {
            intervals.Add(UnityEngine.Random.Range(-0.2f, 0.2f));
        }
        // 랜덤 간격의 합 계산
        float totalRandom = 0;
        foreach (float val in intervals)
        {
            totalRandom += val;
        }

        // 랜덤 간격과 함께 평균 간격을 계산
        float averageInterval = (duration - totalRandom) / totalApples;

        // 슬라이더의 최대 값 설정
        //timerSlider.maxValue = duration;
        //timerSlider.value = duration;

        float elapsed = 0; // 경과 시간

        for (int i = 0; i < totalApples; i++)
        {
            yield return new WaitForSeconds(averageInterval + intervals[i]); // 무작위 간격 + 평균 간격

            GameObject apple = Instantiate(applePrefab);
            
            apple.transform.position = new Vector2(UnityEngine.Random.Range(-7.5f, 7.5f), UnityEngine.Random.Range(5.5f, 7f)); // 랜덤 위치
            Rigidbody2D appleRb = apple.AddComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트 추가
            appleRb.gravityScale = UnityEngine.Random.Range(2f, 4f); // 랜덤 속도

            // x축 방향으로 무작위 힘 추가
            appleRb.AddForce(new Vector2(UnityEngine.Random.Range(-1f, 1f), 0), ForceMode2D.Impulse);

            foreach (var existingApple in apples)
            {
                var appleComponent = apple.GetComponent<Collider2D>();
                if (appleComponent != null && existingApple != null)
                {
                    Physics2D.IgnoreCollision(appleComponent, existingApple.GetComponent<Collider2D>());
                }
            }
            apple.gameObject.GetComponent<SpriteRenderer>().sprite = appleImages[UnityEngine.Random.Range(0, 7)];   // 사과 이미지 랜덤
            apples.Add(apple);

            // 경과 시간 업데이트
            elapsed += averageInterval + intervals[i];
            // 슬라이더 값 업데이트
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
        apples.Remove(apple); // 사과를 리스트에서 제거
        Destroy(apple); // 사과를 파괴
        //applecount.text = "남은 사과 수: " + (totalApples - (score + missscore)).ToString();
    }

    public void IncreaseScore()
    {
        score++;
        score_text.text = score.ToString();
        //accuracy.text = "정확도: " + (((score / (score + missscore)) * 100).ToString("F2")) + "%";

    }

    public void MissScore()
    {
        missscore++;
        //miss_text.text = "놓친 사과 수: " + missscore.ToString();
    }
}
