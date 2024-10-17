public class Reflector
{
    private readonly string wiring;

    public Reflector(string wiring)
    {
        this.wiring = wiring;
    }

    public char Reflect(char character)
    {
        int inputPosition = character - 'A';
        return wiring[inputPosition];
    }
}
