using System.Collections.Generic;

public class Plugboard
{
    private Dictionary<char, char> connections = new();

    public Plugboard(string wiring)
    {
        foreach (string pair in wiring.Split(' '))
        {
            connections[pair[0]] = pair[1];
            connections[pair[1]] = pair[0];
        }
    }

    public char Swap(char character)
    {
        return connections.ContainsKey(character) ? connections[character] : character;
    }
}
