using System.Collections.Generic;
using UnityEngine;

namespace _Assets.DataChooser.Scripts.DataChooser.Data.Services.Storage
{
    public interface IGameDatabase
    {
        IReadOnlyList<T> GetAll<T>() where T : ScriptableObject, IData;
        T GetNext<T>(T current) where T : ScriptableObject, IData;
        T GetPrevious<T>(T current) where T : ScriptableObject, IData;
    }
}