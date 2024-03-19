using UnityEngine;

[CreateAssetMenu(fileName = "WeponSO", menuName = "SO/WeponSO")]
public class WeponSO : ScriptableObject
{
    public string weponId = "weponId";
    public Sprite sprite;
    public BulletName nameBullet = BulletName.noName;
}
