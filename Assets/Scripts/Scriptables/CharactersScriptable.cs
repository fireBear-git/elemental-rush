using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/Create CharactersScriptable", fileName = "CharacterScriptable")]
public class CharactersScriptable : ScriptableObject
{
    [SerializeField] private Character[] _characters;
}
