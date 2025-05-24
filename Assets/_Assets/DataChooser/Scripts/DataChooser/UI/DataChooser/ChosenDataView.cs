using _Assets.DataChooser.Scripts.DataChooser.Data;
using UnityEngine;

namespace _Assets.DataChooser.Scripts.DataChooser.UI.DataChooser
{
    public abstract class ChosenDataView : MonoBehaviour
    {
        public abstract void Initialize(IData data);
    }
}