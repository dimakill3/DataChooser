using _Assets.DataChooser.Scripts.DataChooser.Data.SO;
using UnityEngine;

namespace _Assets.DataChooser.Demos.LevelDemo.Scripts.Data.SO
{
    [CreateAssetMenu(fileName = "Level Data Collection", menuName = "Data/LevelDataCollection")]
    public class LevelDataCollection : DataCollection<LevelData>
    {
    }
}