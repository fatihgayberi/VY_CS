using UnityEngine;
using VY_CS.AmmoSystem.Bullet;

namespace VY_CS.AmmoSystem.BulletVariants
{
    public class BulletRiffle : BulletBase
    {
        public override void Move()
        {
            transform.position += Vector3.right * 3f * Time.fixedDeltaTime;
        }
    }
}