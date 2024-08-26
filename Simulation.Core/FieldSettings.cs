namespace Simulation.Core;

public class FieldSettings
{
    private int _fieldWidth = 10;
    private int _fieldHeight = 10;

    public int FieldWidth
    {
        get => _fieldWidth;
        set
        { 
            if (value <= 0)
                throw new ArgumentException("Field width must be larger than zero.");
            _fieldWidth = value;
        }
    }

    public int FieldHeight
    {
        get => _fieldHeight;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Field height must be larger than zero.");
            _fieldHeight = value;
        }
    }
}
