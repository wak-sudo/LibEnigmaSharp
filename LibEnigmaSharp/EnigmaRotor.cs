namespace LibEnigmaSharp
{
    /// <summary>
    /// Class holding enigma-friendly rotor
    /// </summary>
    class EnigmaRotor
    {
        public string AlphabetRing { get; private set; }

        public int Notch { get; private set; }

        public int Position { get; set; }

        public int RingSetting { get; private set; }

        public EnigmaRotor(string AlphabetRing, int Notch, int InitialPosition, int RingSetting)
        {
            this.AlphabetRing = AlphabetRing;
            this.Notch = Notch;
            this.Position = InitialPosition;
            this.RingSetting = RingSetting;
        }
    }
}
