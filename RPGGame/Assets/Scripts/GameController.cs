using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField]
    private Potion _potion;
    [SerializeField]
    private Player _player;
    [SerializeField]
    private Bridge _bridge;
    [SerializeField]
    private GameObject _fire;

    void Update()
    {

        if (_bridge.ShouldBreakBridge && !_player.IsPlayerHighlited)
        {
            _bridge.Break();
        }
        if (_potion.HasPlayerPickedUpPotion)
        {
            _player.HighlightPlayer();
        }

        if (_bridge.ShouldSetFireActive)
        {
            SetFireActive();
        }
        
    }
    
    private void SetFireActive()
    {
        _fire.SetActive(true);
    }
}
