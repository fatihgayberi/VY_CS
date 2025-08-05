using System;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace VY_CS.AmmoSystem.Bullet
{
    public abstract class BulletBase : MonoBehaviour, IBullet
    {
        public Action<BulletBase> BulletLifeFinished { get; set; }

        public abstract void Move();

        public virtual void LifeStart()
        {
            LifeLoop().Forget();
        }
        public virtual void LifeFinish()
        {
            BulletLifeFinished?.Invoke(this);
        }

        private async UniTaskVoid LifeLoop()
        {
            float lifetime = 3f;
            float elapsedTime = 0f;

            while (elapsedTime < lifetime)
            {
                Move();
                await UniTask.Yield(timing: PlayerLoopTiming.FixedUpdate);
                elapsedTime += Time.fixedDeltaTime;
            }

            LifeFinish();
        }
    }
}
