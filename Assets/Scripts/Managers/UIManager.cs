using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image[] _bullets;
    [SerializeField] private Sprite EmptyBulletImage;
    [SerializeField] private Sprite FilledBulletImage;

    public void BulletDecrease(int bullets)
    {
        _bullets[bullets].sprite = EmptyBulletImage;
    }

    public void BulletIncrease(int bullets)
    {
        _bullets[bullets].sprite = FilledBulletImage;
    }
}
