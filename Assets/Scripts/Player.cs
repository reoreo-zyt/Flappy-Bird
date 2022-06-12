using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction;
    // 重力
    public float gravity = -9.8f;
    // 方向移动距离
    public float strength = 5f;

    public void Update() 
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
}
