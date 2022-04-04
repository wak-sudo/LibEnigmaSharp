using System;

namespace LibEnigmaSharp
{
    // TODO: Implement enums

    /// <summary>
    /// Class implementation of Enigma
    /// </summary>
    public class Encoder
    {
        const int alphabetLength = 26;

        private readonly EnigmaSettings Settings;

        /// <summary>
        /// Constructor, takes user settings and converts them to enigma-friendly settings
        /// </summary>
        public Encoder(UserSettings Settings)
        {
            SettingsConversion Conversion = new SettingsConversion();
            this.Settings = Conversion.ConvertToEnigmaSettings(Settings);
        }

        /// <summary>
        /// Encrypts/decrypts given text
        /// </summary>
        public string EncryptText(string origninalText)
        {
            string EncryptedText = "";
            for (int i = 0; i < origninalText.Length; i++)
            {
                char letter = Char.ToUpper(origninalText[i]);
                if (letter >= 'A' && letter <= 'Z')
                    EncryptedText += EncryptChar(letter);
            }
            return EncryptedText;
        }

        /// <summary>
        /// Returns rotors position.
        /// </summary>
        /// <returns>3 elements char array</returns>
        public char[] ReturnRotorsPosition()
        {
            char[] arr =
            {
                (char)(Settings.Rotors[0].Position+'A'),
                (char)(Settings.Rotors[1].Position+'A'),
                (char)(Settings.Rotors[2].Position+'A'),
            };
            return arr;
        }

        /// <summary>
        /// Encrypts/decrypts given character, main logic
        /// </summary>
        private char EncryptChar(char letter)
        {
            StepRotors();

            letter = Settings.PlugboardConnections[letter];

            // Pre-reflector encoding
            for (int i = Settings.Rotors.Length - 1; i >= 0; i--)
                letter = EnigmaPreRefEncoding(letter, i);

            letter = Settings.ReflectorAlphabet[letter - 'A'];

            // Post-reflector encoding
            for (int i = 0; i < Settings.Rotors.Length; i++)
                letter = EnigmaPostRefEncoding(letter, i);

            letter = Settings.PlugboardConnections[letter];

            return letter;
        }

        /// <summary>
        /// Handles encryption in the pre-reflector encoding phase
        /// </summary>
        private char EnigmaPreRefEncoding(char originalCharacter, int encryptionSet)
        {
            int index = Mod((originalCharacter - 'A') + Settings.Rotors[encryptionSet].Position - Settings.Rotors[encryptionSet].RingSetting);

            char modifiedChar = Settings.Rotors[encryptionSet].AlphabetRing[index];

            index = Mod((modifiedChar - 'A') + Settings.Rotors[encryptionSet].RingSetting - Settings.Rotors[encryptionSet].Position);

            return (char)(index + 'A');
        }

        /// <summary>
        /// Handles encryption in the post-reflector encoding phase
        /// </summary>
        private char EnigmaPostRefEncoding(char originalCharacter, int encryptionSet)
        {
            int index = Mod((originalCharacter - 'A') + Settings.Rotors[encryptionSet].Position - Settings.Rotors[encryptionSet].RingSetting);

            char modifiedChar = (char)(index + 'A');

            index = Mod(Settings.Rotors[encryptionSet].AlphabetRing.IndexOf(modifiedChar) + Settings.Rotors[encryptionSet].RingSetting - Settings.Rotors[encryptionSet].Position);

            return (char)(index + 'A');
        }

        /// <summary>
        /// Handles stepping and checks turnover positions
        /// </summary>
        private void StepRotors()
        {
            if (Settings.Rotors[1].Position == Settings.Rotors[1].Notch)
            {
                // Double step sequence, ex.:
                // ADV -> step -> AEW -> step -> BFX

                Settings.Rotors[1].Position = (Settings.Rotors[1].Position + 1) % alphabetLength;
                Settings.Rotors[0].Position = (Settings.Rotors[0].Position + 1) % alphabetLength;
            }
            else if (Settings.Rotors[2].Position == Settings.Rotors[2].Notch)
            {
                Settings.Rotors[1].Position = (Settings.Rotors[1].Position + 1) % alphabetLength;
            }
            Settings.Rotors[2].Position = (Settings.Rotors[2].Position + 1) % alphabetLength;
        }

        /// <summary>
        /// Modulo implementation, ex. Mod(-3, 26) = 23
        /// </summary>
        private int Mod(int i, int k = alphabetLength)
        {
            int reminder = i % k;
            if (reminder >= 0)
                return reminder;
            else return reminder + k;
        }

    }
}
