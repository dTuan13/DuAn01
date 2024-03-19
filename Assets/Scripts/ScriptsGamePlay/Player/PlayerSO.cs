using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "SO/PlayerSO")]
public class PlayerSO : ScriptableObject
{
    public string playerId = "playerId";
    public Sprite sprite;
    public int hpMax = 100;
    public float moveSpeed = 3.1f;
    public RuntimeAnimatorController animator;
}
