using System;

namespace VY_CS.AmmoSystem.Bullet
{
    public interface IBullet
    {
        public Action<BulletBase> BulletLifeFinished { get; set; }

        public void LifeStart();
        public void LifeFinish();
    }
}