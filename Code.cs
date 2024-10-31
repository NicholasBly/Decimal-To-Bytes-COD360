public void WriteRatioValue(uint offset, decimal value1, decimal value2)
{
    if (value2 == 0)
    {
        MessageBox.Show("Cannot divide by zero.");
    }
    else
    {
        decimal result = value1 / value2;

        result = Math.Round(result, 3);

        byte[] bytes = CalculateBytes(result);

        Console.SetMemory(offset, new byte[4]);
        Console.SetMemory(offset, bytes);
    }
}

private byte[] CalculateBytes(decimal value)
{
    byte[] bytes = new byte[4];
    if (value >= 65.536m)
    {
        if (value >= 0xFF)
        {
            bytes[3] = 0xFF;
        }
        else
        {
            bytes[3] = (byte)(value / 65.536m);
        }
        value -= bytes[3] * 65.536m;
    }
    if (value >= 0.256m)
    {
        if (value >= 0xFF)
        {
            bytes[2] = 0xFF;
        }
        else
        {
            bytes[2] = (byte)(value / 0.256m);
        }
        value -= bytes[2] * 0.256m;
    }
    if (value >= 0.001m)
    {
        if (value >= 0xFF)
        {
            bytes[1] = 0xFF;
        }
        else
        {
            bytes[1] = (byte)(value / 0.001m);
        }
        value -= bytes[1] * 0.001m;
    }
    return bytes;
}

//Calling the function
    WriteRatioValue((uint)Stats.KDRatio, numericUpDown2.Value, numericUpDown3.Value);
    WriteRatioValue((uint)Stats.WinLossRatio, numericUpDown6.Value, numericUpDown7.Value);
