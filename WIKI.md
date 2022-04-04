## General information ##
To decrypt a message, the same settings applied to its encryption have to be used.

Supported wiring tables:
```
Rotors:

I   EKMFLGDQVZNTOWYHXUSPAIBRCJ
II  AJDKSIRUXBLHWTMCQGZNPYFVOE
III BDFHJLCPRTXVZNYEIWGAKMUSQO
IV  ESOVPZJAYQUIRHXLNFTGKDCMWB
V   VZBRGITYUPSDNHLXAWMJQOFECK

Reflectors:

ETW ABCDEFGHIJKLMNOPQRSTUVWXYZ
B   YRUHQSLDPXNGOKMIEBFZCWVJAT
C   FVPJIAOYEDRZXWGCTKUQSBNMHL
```

Starting positions and ring settings are defined by an alphabet:
```
A B C D E F G H I J  K  L  M  N  O  P  Q  R  S  T  U  V  W  X  Y  Z
| | | | | | | | | |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |
0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25
```
## Documentation ##
### UserRotor class ###

Stores information about the rotor.

#### Constructor ####
```
UserRotor(string RotorNumber, string InitalPosition, string RingSetting)
```
Constructs a UserRotor object.

### UserSettings class ###

Stores user settings.

#### Constructor ####
```
UserSettings(string ReflectorName, UserRotor[] Rotors, string[] PlugboardConnections = null)
```
Constructs a UserSettings object from reflector, rotors and optional plug board connections.

#### Methods ####
```
bool CanBeConverted()
```
Checks whether the UserSettings object can be safely  passed to the constructor of the Encoder class.

### Encoder class ###

Handles text encryption/decryption.

#### Constructor ####
```
Encoder(UserSettings Settings)
```
Constructs an Encoder object that utilities passed settings. If settings are not valid, an exception will be thrown.

#### Methods ####
```
string EncryptText(string origninalText)
```
Takes text and returns an encrypted/decrypted version. Skips anything except lowercase and uppercase letters.

```
char[] ReturnRotorsPosition()
```
Returns a 3 element char array corresponding to the position of the rotors. Positions are given in alphabetical order (described in "General information").


## Example ##
```
UserRotor[] rotors =
{
  new UserRotor("I", "C", "F"),
  new UserRotor("II", "B", "G"),
  new UserRotor("III", "D", "D")
};
string[] plugboard = { "AZ", "BC" };
UserSettings settings = new UserSettings("B", rotors, plugboard);

if (settings.CanBeConverted())
{
  Encoder enigma = new Encoder(settings);
  string encryptedText = enigma.EncryptText("The quick brown fox jumps over the lazy dog.");
}
// output: ALKIXOBUZNSHKZUJKQGADEQSIFTLIKKNRQR
```
