using UnityEngine;

public class Player : MonoBehaviour
{
    // 动画
    private SpriteRenderer spriteRenderer;
    // 通过设置为public将sprites图加载进去
    public Sprite[] sprites;
    private int spriteIndex;
    private Vector3 direction;
    // 重力
    public float gravity = -9.8f;
    // 方向移动距离
    public float strength = 5f;

    // 初始化时被调用
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        // 重复调用函数
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void Update() 
    {
        // 空格键或者鼠标单击
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // 方向设置为向上
            direction = Vector3.up * strength;
        }

        // 手机触摸的情况
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // 触摸刚开始
            if(touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }

        // 间隔时间下降，更新鸟的位置
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void AnimateSprite()
    {
        spriteIndex++;

        if(spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }
}
