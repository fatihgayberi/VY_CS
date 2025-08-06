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

        private void Start()
        {
            ButtonSetup();
        }

        private void ButtonSetup()
        {
            foreach (var binding in buttons)
            {
                binding.button.onClick.AddListener(() => CreateSkill(binding.skillType));
            }
        }

        public void CreateSkill(SkillType skillType)
        {
            if (currentSkillCount >= maxSkillCount) return;

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
        }

        [Serializable]
        class ButtonBinding
        {
            public SkillType skillType;
            public Button button;
        }
    }
}
