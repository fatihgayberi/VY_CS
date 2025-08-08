using System;
using UnityEngine;
using UnityEngine.UI;
using VY_CS.Character;

namespace VY_CS.SkillSystem
{
    public class SkillFactory : MonoBehaviour
    {
        [SerializeField] private WeaponHandler weaponHandler;
        [SerializeField] private int maxSkillCount;
        [SerializeField] private ButtonBinding[] buttons;

        private int currentSkillCount = 0;

        private void OnEnable()
        {
            GameManager.Instance.GameStart += OnGameStart;
        }
        private void OnDisable()
        {
            GameManager.Instance.GameStart -= OnGameStart;
        }

        private void OnGameStart()
        {
            currentSkillCount = 0;

            foreach (var binding in buttons)
            {
                binding.button.interactable = true;
            }
        }

        private void Start()
        {
            ButtonSetup();
        }

        private void ButtonSetup()
        {
            foreach (var binding in buttons)
            {
                binding.button.onClick.AddListener(() => SkillButton(binding.button, binding.skillType));
            }
        }

        private void SkillButton(Button button, SkillType skillType)
        {
            bool isCreated = CreateSkill(skillType);
            if (isCreated) button.interactable = false;
        }

        private bool CreateSkill(SkillType skillType)
        {
            if (currentSkillCount >= maxSkillCount) return false;

            SkillBase skillBase = skillType switch
            {
                SkillType.SkillBulletSpeed => new SkillBulletSpeed(),
                SkillType.SkillAngularShoot => new SkillAngularShoot(weaponHandler),
                SkillType.SkillClonePlayer => new SkillClonePlayer(weaponHandler),
                SkillType.SkillDoubleShoot => new SkillDoubleShoot(),
                SkillType.SkillFireRate => new SkillFireRate(),
                _ => null
            };

            currentSkillCount++;

            skillBase?.Activate();

            return true;
        }

        [Serializable]
        class ButtonBinding
        {
            public SkillType skillType;
            public Button button;
        }
    }
}
