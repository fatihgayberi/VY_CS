using System;
using UnityEngine;
using System.Threading;
using Wonnasmith.Pooling;
using Cysharp.Threading.Tasks;

namespace VY_CS.AmmoSystem.Bullet
{
    public abstract class BulletBase : MonoBehaviour, IBullet, IPoolable
    {
        public Action<BulletBase> BulletLifeFinished { get; set; }

        private CancellationTokenSource _lifeCts;

        public abstract void Move();

        public virtual void LifeStart()
        {
            _lifeCts = new CancellationTokenSource();
            LifeLoop(_lifeCts.Token).Forget();
        }

        public virtual void LifeFinish()
        {
            BulletLifeFinished?.Invoke(this);
        }

        private void StopLifeLoop()
        {
            _lifeCts?.Cancel();
            _lifeCts?.Dispose();
            _lifeCts = null;
        }

        private async UniTaskVoid LifeLoop(CancellationToken token)
        {
            float lifetime = 3f;
            float elapsedTime = 0f;

            try
            {
                while (elapsedTime < lifetime)
                {
                    token.ThrowIfCancellationRequested();

                    if (this == null) return;

                    Move();
                    await UniTask.Yield(PlayerLoopTiming.FixedUpdate, token);
                    elapsedTime += Time.fixedDeltaTime;
                }

                LifeFinish();
            }
            catch (OperationCanceledException) { }
        }

        public void RePool()
        {
            StopLifeLoop();
            gameObject.SetActive(false);
        }
    }
}
