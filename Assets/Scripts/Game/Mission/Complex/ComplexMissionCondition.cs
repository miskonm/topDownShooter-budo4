using UnityEngine;

namespace TDS.Game.Mission.Complex
{
    public class ComplexMissionCondition : MissionCondition
    {
        [SerializeField] private MissionCondition[] _conditions;

        public MissionCondition[] Conditions => _conditions;
    }
}