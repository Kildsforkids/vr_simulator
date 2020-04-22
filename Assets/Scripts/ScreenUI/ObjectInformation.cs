using UnityEngine;

namespace vr_simulator.ScreenUI
{
    [CreateAssetMenu(fileName = "New Object Information", menuName = "Custom/ObjectInformation")]
    public class ObjectInformation : ScriptableObject
    {
        public string title;
        [TextArea]
        public string description;
        public Sprite image;
    }
}
