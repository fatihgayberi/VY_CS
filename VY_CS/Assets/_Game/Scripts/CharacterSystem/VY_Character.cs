using UnityEngine;
using Wonnasmith.Pooling;

namespace VY_CS.Character
{
    public class VY_Character : MonoBehaviour, IPoolable
    {
        public void RePool()
        {
            gameObject.SetActive(false);
        }
    }
}