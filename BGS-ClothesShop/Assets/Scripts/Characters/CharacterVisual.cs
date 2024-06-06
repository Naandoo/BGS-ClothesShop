using Item;
using UnityEngine;

namespace Character
{
    public class CharacterVisual : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _leftBootField;
        [SerializeField] private SpriteRenderer _rightBootField;
        [SerializeField] private SpriteRenderer _leftElbowField;
        [SerializeField] private SpriteRenderer _rightElbowField;
        [SerializeField] private SpriteRenderer _faceField;
        [SerializeField] private SpriteRenderer _hoodField;
        [SerializeField] private SpriteRenderer _pelvisField;
        [SerializeField] private SpriteRenderer _leftShoulderField;
        [SerializeField] private SpriteRenderer _rightShoulderField;
        [SerializeField] private SpriteRenderer _torsoField;
        [SerializeField] private SpriteRenderer _leftWristField;
        [SerializeField] private SpriteRenderer _rightWristField;
        public Equipments _equipments;

        private void Start()
        {
            UpdateEquipments();
        }

        private void UpdateEquipments()
        {
            SetBoots();
            SetElbows();
            SetFace();
            SetHood();
            SetPelvis();
            SetShoulder();
            SetTorso();
            SetWrist();
        }

        public void SetBoots()
        {
            _leftBootField.sprite = _equipments._bootArmor.Sprite;
            _rightBootField.sprite = _equipments._bootArmor.SecondSideSprite;
        }

        public void SetElbows()
        {
            _leftElbowField.sprite = _equipments._elbowArmor.Sprite;
            _rightElbowField.sprite = _equipments._elbowArmor.SecondSideSprite;
        }

        public void SetFace()
        {
            _faceField.sprite = _equipments._faceArmor.Sprite;
        }

        public void SetHood()
        {
            _hoodField.sprite = _equipments._hoodArmor.Sprite;
        }

        public void SetPelvis()
        {
            _pelvisField.sprite = _equipments._pelvisArmor.Sprite;
        }

        public void SetShoulder()
        {
            _leftShoulderField.sprite = _equipments._shoulderArmor.Sprite;
            _rightShoulderField.sprite = _equipments._shoulderArmor.SecondSideSprite;
        }

        public void SetTorso()
        {
            _torsoField.sprite = _equipments._torsoArmor.Sprite;
        }

        public void SetWrist()
        {
            _leftWristField.sprite = _equipments._wristArmor.Sprite;
            _rightWristField.sprite = _equipments._wristArmor.SecondSideSprite;
        }

    }
}
