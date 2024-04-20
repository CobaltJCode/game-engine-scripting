using UnityEngine;

namespace CharacterEditor
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private MeshRenderer m_Head;
        [SerializeField] private MeshRenderer m_Body;
        [SerializeField] private MeshRenderer m_ArmR;
        [SerializeField] private MeshRenderer m_ArmL;
        [SerializeField] private MeshRenderer m_LegR;
        [SerializeField] private MeshRenderer m_LegL;

        [SerializeField] private GameObject Head;
        [SerializeField] private GameObject Body;
        [SerializeField] private GameObject ArmR;
        [SerializeField] private GameObject ArmL;
        [SerializeField] private GameObject LegR;
        [SerializeField] private GameObject LegL;


        private void Start()
        { 
            Load();
            Material yourMaterial = Resources.Load("Head Material", typeof(Material)) as Material;
            Head.GetComponent<Renderer>().material = yourMaterial;

        }

        public static void Load()
        {
            //Load materials from the MaterialManager and pass in the id pulled from each PlayerPref here
            MaterialManager.Get(BodyTypes.Head, PlayerPrefs.GetInt("Head Material"));
            MaterialManager.Get(BodyTypes.Body, PlayerPrefs.GetInt("Body Material"));
            MaterialManager.Get(BodyTypes.Arm, PlayerPrefs.GetInt("Arm Material"));
            MaterialManager.Get(BodyTypes.Leg, PlayerPrefs.GetInt("Leg Material"));
        }
    }
}