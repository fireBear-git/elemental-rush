using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/Create CharactersScriptable", fileName = "CharacterScriptable")]
public class CharactersScriptable : ScriptableObject
{
    [SerializeField] private Character[] _characters;

    public Character GetCharacter(string id)
    {
        for (int i = 0; i < _characters.Length; i++)
        {
            if(_characters[i].id == id)
                return _characters[i];
        }

        return null;
    }
}
