namespace Backend;

public class Time
{
    // Fields
    private int _hour;
    private int _millisecound;  
    private int _minute;
    private int _second;

    // Constructors
    public Time()
    {
        Hour = 0;
        Minute = 0;
        Second = 0;
        Millisecound = 0;
    }

    public Time(int hour)
    {
        Hour = hour;
        Minute = 0;
        Second = 0;
        Millisecound = 0;
    }

    public Time(int hour, int minute)
    {
        Hour = hour;
        Minute = minute;
        Second = 0;
        Millisecound = 0;
    }

    public Time(int hour, int minute, int second)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecound = 0;
    }

    public Time(int hour, int minute, int second, int millisecound)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecound = millisecound;
    }


    // Properties
    public int Hour 
    {
        get => _hour; 
        set => _hour = ValidHour(value); 
    }
    public int Millisecound 
    { 
        get => _millisecound; 
        set => _millisecound = ValidMillisecound(value); 
    }
    public int Minute 
    { 
        get => _minute; 
        set => _minute = ValidMinute(value); 
    }
    public int Second
    { 
        get => _second;
        set => _second = ValidSecond(value); 
    }

    // Public Methods
    public Time Add(Time other)
    {
        const long msPerDay = 24L * 3600 * 1000;
        long total = (this.ToMillisecounds() + other.ToMillisecounds()) % msPerDay;

        int h = (int)(total / 3600000L);
        total %= 3600000L;
        int m = (int)(total / 60000L);
        total %= 60000L;
        int s = (int)(total / 1000L);
        int ms = (int)(total % 1000L);

        return new Time(h, m, s, ms);
    }

    public bool IsOtherDay(Time other)
    {
        const long msPerDay = 24L * 3600 * 1000;
        long total = this.ToMillisecounds() + other.ToMillisecounds();
        return total >= msPerDay;
    }

    public long ToMillisecounds() => ((long)Hour * 3600 + Minute * 60 + Second) * 1000L + Millisecound;

    public long ToSeconds() => ToMillisecounds() / 1000L;

    public long ToMinutes() => ToMillisecounds() / 60000L;

    public override string ToString() 
    {
        int hour12 = _hour % 12;
        if (hour12 == 0) hour12 = 12;
        string ampm = _hour < 12 ? "AM" : "PM";

        return $"{hour12:D2}:{_minute:D2}:{_second:D2}.{_millisecound:D3} {ampm}";
    }

    // Private Methods
    private int ValidHour(int hour)
    {
        if (hour < 0 || hour > 23)
        { 
            throw new Exception($"The hour: {hour} is invalid.");
        }
        return hour;
    }

    private int ValidMinute(int minute)
    {
        if (minute < 0 || minute > 59)
        {
            throw new Exception($"The minute: {minute} is invalid.");
        }
        return minute;
    }

    private int ValidSecond(int second)
    {
        if (second < 0 || second > 59)
        {
            throw new Exception($"The second: {second} is invalid.");
        }
        return second;
    }

    private int ValidMillisecound(int millisecound)
    {
        if (millisecound < 0 || millisecound > 999)
        {
            throw new Exception($"The millisecound: {millisecound} is invalid.");
        }
        return millisecound;
    }
}
