namespace LibEnigmaSharp
{
    /// <summary>
    /// Class holding user settings
    /// </summary>
    public class UserSettings
    {
        public string ReflectorName { get; private set; }

        public UserRotor[] Rotors { get; private set; }

        public string[] PlugboardConnections { get; private set; }

        public UserSettings(string ReflectorName, UserRotor[] Rotors, string[] PlugboardConnections = null)
        {
            this.ReflectorName = ReflectorName;
            this.Rotors = Rotors;
            this.PlugboardConnections = PlugboardConnections ?? new string[0];
        }

        public bool CanBeConverted()
        {
            try
            {
                SettingsConversion ConvertedArgs = new SettingsConversion();
                var test = ConvertedArgs.ConvertToEnigmaSettings(this);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
