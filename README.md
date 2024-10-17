# EnigmaCrypt.Net

**EnigmaCrypt.Net** is a .NET library that simulates the Enigma machine for encryption and decryption of messages. This library allows you to encrypt and decrypt messages using configurable rotors, a reflector, and a plugboard. It supports uppercase letters, spaces, and numbers

## Installation

You can install the package via NuGet:

`dotnet add package EnigmaCrypt.Net`


## Usage

To use EnigmaCrypt.Net, create an instance of EnigmaMachine with your desired rotor, reflector, and plugboard configurations. After initializing, you can call the Encrypt method to encrypt your message. The same method can be used to decrypt by passing the encrypted text. Below is a simple example:

```csharp
using System;

public class Program
{
    public static void Main()
    {
        var rotorI = new Rotor("EKMFLGDQVZNTOWYHXUSPAIBRCJ", "Q");
        var rotorII = new Rotor("AJDKSIRUXBLHWTMCQGZNPYFVOE", "E");
        var rotorIII = new Rotor("BDFHJLCPRTXVZNYEIWGAKMUSQO", "V");
        var reflectorB = new Reflector("YRUHQSLDPXNGOKMIEBFZCWVJAT");

        var machine = new EnigmaMachine(
            new[] { rotorI, rotorII, rotorIII },
            reflectorB,
            new Plugboard("AE BF CK"),
            "QWE"
        );

        Console.WriteLine("Enter the message to encrypt:");
        string message = Console.ReadLine();

        string encrypted = machine.Encrypt(message);
        Console.WriteLine($"Encrypted message: {encrypted}");

        string decrypted = machine.Encrypt(encrypted); 
        Console.WriteLine($"Decrypted Message: {decrypted}");
    }
}

```
