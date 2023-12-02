using UnityEngine;

public class BasketPlayer : MonoBehaviour
{
    [SerializeField] private GameObject basketPlayer;
    private Player player;
    private Basket basket;
    private SpriteRenderer spriteRenderer;
    private const float SPEED = 12f;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<Player>();
        basket = FindObjectOfType<Basket>();
    }

    // Update is called once per frame
    void Update()
    {
     //   basketPlayerRB.velocity = new Vector3(basketPlayerRB.velocity.x, 0, 0);

        MoveBasketPlayer();
    }

    void MoveBasketPlayer()
    {
        //   Debug.Log(basketPlayer.transform.position.x);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 screenPos = Camera.main.WorldToViewportPoint(transform.position);
        if (screenPos.x > 1f)
        {
            screenPos.x = 1f;
            basketPlayer.transform.position = Camera.main.ViewportToWorldPoint(screenPos);
        }
        else if (screenPos.x < 0f)
        {
            screenPos.x = 0f;
            basketPlayer.transform.position = Camera.main.ViewportToWorldPoint(screenPos);
        }
        else
        {
            if (System.Math.Abs(basketPlayer.transform.position.x - mousePos.x) < SPEED * Time.deltaTime)
            {
                basketPlayer.transform.position = new Vector3(mousePos.x, basketPlayer.transform.position.y, basketPlayer.transform.position.z);
            }
            else
            {
                if (basketPlayer.transform.position.x != mousePos.x)
                {
                    player.Run();
                    if (basketPlayer.transform.position.x > mousePos.x)
                    {
                        basketPlayer.transform.position = basketPlayer.transform.position - new Vector3(SPEED, 0, 0) * Time.deltaTime;
                        player.ToLeft();
                        basket.ToLeft();

                    }
                    else
                    {
                        basketPlayer.transform.position = basketPlayer.transform.position + new Vector3(SPEED, 0, 0) * Time.deltaTime;
                        player.ToRight();
                        basket.ToRight();
                    }
                }
                else
                {
                    player.StopRun();
                }
            }
        }
    }
}
