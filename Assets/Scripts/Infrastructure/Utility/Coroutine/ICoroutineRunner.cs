using System.Collections;
using UnityEngine;

namespace TDS.Infrastructure.Utility
{
    public interface ICoroutineRunner : IService
    {
        Coroutine StartCoroutine(IEnumerator enumerator);
    }
}