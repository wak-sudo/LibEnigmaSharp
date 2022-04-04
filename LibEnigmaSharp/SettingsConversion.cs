using System;
using System.Collections.Generic;

namespace LibEnigmaSharp
{
    /// <summary>
    /// Class designed for converting user input to enigma-friendly settings
    /// </summary>
    class SettingsConversion
    {
        private const int ValidNumberOfRotors = 3;

        private const int MaxNumberOfConnections = 13;

        /// <summary>
        /// Transforms user input to enigma-friendly settings
        /// </summary>
        public EnigmaSettings ConvertToEnigmaSettings(UserSettings UserOptions)
        {
            try
            {
                string ReflectorAlphabet = ConvertReflector(UserOptions.ReflectorName);
                EnigmaRotor[] Rotors = ConvertRotors(UserOptions.Rotors);
                Dictionary<char, char> PlugboardConnections = CreatePlugboardConnections(UserOptions.PlugboardConnections);

                return new EnigmaSettings(ReflectorAlphabet, Rotors, PlugboardConnections);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Converts user rotors to enigma-friendly rotors
        /// </summary>
        private EnigmaRotor[] ConvertRotors(UserRotor[] UserRotors)
        {

            if (UserRotors.Length == ValidNumberOfRotors)
            {
                EnigmaRotor[] RefinedRotors = new EnigmaRotor[ValidNumberOfRotors];
                for (int i = 0; i < UserRotors.Length; i++)
                    RefinedRotors[i] = ConvertRotor(UserRotors[i]);

                return RefinedRotors;
            }
            else throw new Exception("The number of rotors is not equal " + ValidNumberOfRotors.ToString());
        }

        /// <summary>
        /// Converts user rotor to enigma-friendly rotor
        /// </summary>
        private EnigmaRotor ConvertRotor(UserRotor Rotor)
        {
            return new EnigmaRotor(ConvertRotorAlphabet(Rotor.RotorNumber),
                                   ConvertRotorNotch(Rotor.RotorNumber),
                                   ConvertCharacterToDecimal(Rotor.InitialPosition),
                                   ConvertCharacterToDecimal(Rotor.RingSetting));
        }

        /// <summary>
        /// Converts alphabetical rotor position or alphabetical rotor setting to their numerical equivalent.
        /// </summary>
        private int ConvertCharacterToDecimal(string Character)
        {
            if (Character.Length == 1)
            {
                if (Character[0] >= 'A' && Character[0] <= 'Z')
                {
                    return (Character[0] - 'A');
                }
                else throw new Exception("An incorrect character passed to decimal conversion");
            }
            else throw new Exception("Character passed to decimal conversion has an incorrect length");
        }

        /// <summary>
        /// Creates enigma plugboard connections from user input
        /// </summary>
        private Dictionary<char, char> CreatePlugboardConnections(string[] Connections)
        {
            if (Connections.Length <= MaxNumberOfConnections)
            {
                Dictionary<char, char> Plugboard = new Dictionary<char, char>();
                for (int i = 0; i < Connections.Length; i++)
                {
                    if (Connections[i].Length == 2)
                    {
                        int sumOfBytes = Connections[i][0] + Connections[i][1];

                        if (Connections[i][0] != Connections[i][1] && sumOfBytes <= 180 && sumOfBytes >= 130) // out of A - Z range
                        {
                            if (!Plugboard.ContainsKey(Connections[i][0]) && !Plugboard.ContainsKey(Connections[i][1]))
                            {
                                Plugboard.Add(Connections[i][0], Connections[i][1]);
                                Plugboard.Add(Connections[i][1], Connections[i][0]);
                            }
                            else
                                throw new Exception("Connection already used");
                        }
                        else throw new Exception("Invalid connection");
                    }
                    else throw new Exception("Invalid connection length");
                }

                // Fill the rest of dictionary with characters corresponding only to themselves
                for (char i = 'A'; i <= 'Z'; i++)
                    if (!Plugboard.ContainsKey(i))
                        Plugboard.Add(i, i);

                return Plugboard;
            }
            else throw new Exception("Too many connections");
        }

        /// <summary>
        /// Converts user rotor number to the corresponding alphabet ring
        /// </summary>
        private string ConvertRotorAlphabet(string RotorNumber)
        {
            return RotorNumber switch
            {
                "I" => "EKMFLGDQVZNTOWYHXUSPAIBRCJ",
                "II" => "AJDKSIRUXBLHWTMCQGZNPYFVOE",
                "III" => "BDFHJLCPRTXVZNYEIWGAKMUSQO",
                "IV" => "ESOVPZJAYQUIRHXLNFTGKDCMWB",
                "V" => "VZBRGITYUPSDNHLXAWMJQOFECK",
                _ => throw new Exception("Unidentified rotor number"),
            };
        }

        /// <summary>
        /// Converts user rotor number to the corresponding ring notch
        /// </summary>
        private int ConvertRotorNotch(string RotorNumber)
        {
            return RotorNumber switch
            {
                "I" => 16,
                "II" => 4,
                "III" => 21,
                "IV" => 9,
                "V" => 25,
                _ => throw new Exception("Unidentified rotor number"),
            };
        }

        /// <summary>
        /// Converts user reflector name to the corresponding alphabet ring
        /// </summary>
        private string ConvertReflector(string ReflectorName)
        {
            return ReflectorName switch
            {
                "ETW" => "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                "B" => "YRUHQSLDPXNGOKMIEBFZCWVJAT",
                "C" => "FVPJIAOYEDRZXWGCTKUQSBNMHL",
                _ => throw new Exception("Unidentified reflector"),
            };
        }
    }
}
