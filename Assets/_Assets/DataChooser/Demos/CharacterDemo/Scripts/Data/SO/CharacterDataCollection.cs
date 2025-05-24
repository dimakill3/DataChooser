using _Assets.DataChooser.Scripts.DataChooser.Data.SO;
using UnityEngine;

namespace _Assets.DataChooser.Demos.CharacterDemo.Scripts.Data.SO
{
    [CreateAssetMenu(fileName = "Character Data Collection", menuName = "Data/CharacterDataCollection")]
    public class CharacterDataCollection : DataCollection<CharacterData>
    {
    }
}