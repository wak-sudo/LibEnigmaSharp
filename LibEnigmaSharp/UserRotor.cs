namespace LibEnigmaSharp
{
    /// <summary>
    /// Class holding user rotor settings
    /// </summary>
    public class UserRotor
    {

        public string RotorNumber { get; private set; }

        public string InitialPosition { get; private set; }

        public string RingSetting { get; private set; }

        public UserRotor(string RotorNumber, string InitalPosition, string RingSetting)
        {
            this.RotorNumber = RotorNumber;
            this.InitialPosition = InitalPosition;
            this.RingSetting = RingSetting;
        }

    }
}
