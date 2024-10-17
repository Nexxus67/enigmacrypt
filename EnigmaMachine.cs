public class EnigmaMachine
{
    private Rotor[] rotors;
    private Reflector reflector;
    private Plugboard plugboard;

    public EnigmaMachine(Rotor[] rotors, Reflector reflector, Plugboard plugboard, string initialPositions)
    {
        this.rotors = rotors;
        this.reflector = reflector;
        this.plugboard = plugboard;
        SetRotorPositions(initialPositions);
    }

    private void SetRotorPositions(string initialPositions)
    {
        for (int i = 0; i < rotors.Length; i++)
        {
            rotors[i].Position = initialPositions[i];
        }
    }

    public string Encrypt(string input)
    {
        string encryptedMessage = "";
        foreach (char character in input)
        {
            encryptedMessage += EncryptCharacter(character);
        }
        return encryptedMessage;
    }

    private char EncryptCharacter(char character)
    {
        if (char.IsWhiteSpace(character) || char.IsDigit(character))
        {
            return character; 
        }

        if (char.IsLower(character))
        {
            character = char.ToUpper(character);
        }

        character = plugboard.Swap(character);
        foreach (Rotor rotor in rotors)
        {
            character = rotor.Forward(character);
        }
        character = reflector.Reflect(character);
        for (int i = rotors.Length - 1; i >= 0; i--)
        {
            character = rotors[i].Reverse(character);
        }
        character = plugboard.Swap(character);
        RotateRotors();
        return character;
    }

    private void RotateRotors()
    {
        foreach (Rotor rotor in rotors)
        {
            if (!rotor.Rotate())
                break;
        }
    }
}
