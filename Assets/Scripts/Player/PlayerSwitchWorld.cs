using UnityEngine;

namespace JPO
{
    public class PlayerSwitchWorld : MonoBehaviour
    {
        private PlayerController _controller;

        [SerializeField]private GameObject overWorld;
        [SerializeField] private GameObject ghostWorld;

        [SerializeField] private SpriteRenderer rend;
        [SerializeField] private Sprite normalSprite;
        [SerializeField] private Sprite ghostSprite;



        private bool _isInOverworld;

        private void Awake()
        {
            _controller = GetComponent<PlayerController>();
            _controller.onSwitchWorld.AddListener(HandleSwitchWorld);
            _isInOverworld = true;
        }
        private void OnDestroy()
        {
            _controller.onSwitchWorld.RemoveListener(HandleSwitchWorld);
        }
        private void HandleSwitchWorld()
        {
            _isInOverworld = !_isInOverworld;
            overWorld.SetActive(_isInOverworld);
            ghostWorld.SetActive(!_isInOverworld);
            rend.sprite = _isInOverworld ? normalSprite : ghostSprite;
        }
    }
}
