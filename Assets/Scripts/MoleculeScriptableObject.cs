using UnityEngine;

[CreateAssetMenu(fileName = "MoleculeSO", menuName = "ScritableObjects/Molecule")]
public class MoleculeScriptableObject : ScriptableObject
{
    public string molName;
    public string type;
    public GameObject model;
    public string color;
}
