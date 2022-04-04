# LibEnigmaSharp

A simple library created for encrypting/decrypting texts with Enigma.

## How to build

Build using Visual Studio and .NET Core 3.1.

## Details

Supports:
- Encryption/decryption
- Rotors position peeking
- Specifying settings
  - Wheel order (Walzenlage) (three-rotor machine)
  - Starting position of the rotors (Grundstellung) 
  - Ring settings (Ringstellung)
  - Plug connections (Steckerverbindungen)

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

## Usage

See [Wiki](https://github.com/wak-sudo/LibEnigmaSharp/blob/master/WIKI.md)
