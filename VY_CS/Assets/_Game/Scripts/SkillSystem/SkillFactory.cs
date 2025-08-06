using UnityEngine;

namespace VY_CS.SkillSystem
{
    public class SkillFactory : MonoBehaviour
    {
        [SerializeField] private int maxSkillCount;

        private int currentSkillCount = 0;

        public void CreateSkill(SkillType skillType)
        {
            if (currentSkillCount >= maxSkillCount) return;

            SkillBase skillBase = skillType switch
            {
                SkillType.SkillBulletSpeed => new SkillBulletSpeed(),
                SkillType.SkillAngularShoot => new SkillAngularShoot(),
                SkillType.SkillClonePlayer => new SkillClonePlayer(),
                SkillType.SkillDoubleShoot => new SkillDoubleShoot(),
                SkillType.SkillFireRate => new SkillFireRate(),
                _ => null
            };

            currentSkillCount++;

            skillBase?.Activate();
        }

        public void SkillButtonPressed()
        {
            CreateSkill(SkillType.SkillDoubleShoot);
        }
    }
}
