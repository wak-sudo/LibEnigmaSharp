using System.Collections.Generic;

namespace LibEnigmaSharp
{
    /// <summary>
    /// Class holding enigma-friendly settings
    /// </summary>
    class EnigmaSettings
    {
        public string ReflectorAlphabet { get; private set; }

        public EnigmaRotor[] Rotors { get; private set; } = new EnigmaRotor[3];

        public Dictionary<char, char> PlugboardConnections { get; private set; }

        public EnigmaSettings(string ReflectorAlphabet, EnigmaRotor[] Rotors, Dictionary<char, char> PlugboardConnections)
        {
            this.ReflectorAlphabet = ReflectorAlphabet;
            this.Rotors = Rotors;
            this.PlugboardConnections = PlugboardConnections;
        }
    }
}
