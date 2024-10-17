public class Rotor
{
    private readonly string wiring;
    private readonly string notch;
    private int position;

      public char Position
    {
        get => (char)('A' + position);
        set => position = value - 'A';
    }

    public Rotor(string wiring, string notch)
    {
        this.wiring = wiring;
        this.notch = notch;
        position = 0;
    }

    public char Forward(char character)
    {
        int inputPosition = (character - 'A' + position) % 26;
        return (char)((wiring[inputPosition] - 'A' - position + 26) % 26 + 'A');
    }

    public char Reverse(char character)
    {
        int outputPosition = (wiring.IndexOf(character) - position + 26) % 26;
        return (char)(outputPosition + 'A');
    }

    public bool Rotate()
    {
        position = (position + 1) % 26;
        return notch.Contains((char)('A' + position));
    }
}
