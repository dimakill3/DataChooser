using _Assets.Scripts.DataChooser.Data;
using UnityEngine;

namespace _Assets.Scripts.DataChooser.UI.DataChooser
{
    public abstract class ChosenDataView : MonoBehaviour
    {
        public abstract void Initialize(IData data);
    }
}