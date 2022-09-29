using System;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyDeath : MonoBehaviour
    {
        public event Action<EnemyDeath> OnHappened;
    }
}