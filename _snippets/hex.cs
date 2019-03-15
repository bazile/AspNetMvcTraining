static string ToHexString(byte[] array)
{
    if (array == null || array.Length == 0) return "";
    var sb = new StringBuilder(array.Length*2);
    for (int i = 0; i < array.Length; i++)
    {
        sb.Append(array[i].ToString("X2"));
    }
    return sb.ToString();
}

static byte[] FromHexString(string hex)
{
    if (hex == null || hex.Length == 0) return Array.Empty<byte>();
    if (hex.Length%2 == 1) throw new InvalidOperationException("String length must be even number");
    
    byte[] array = new byte[hex.Length/2];
    for (int i = 0; i < hex.Length; i+=2)
    {
        array[i/2] = (byte)((GetHexVal(hex[i]) << 4) + (GetHexVal(hex[i + 1])));
    }
    return array;
}

public static int GetHexVal(char hex)
{
    int val = (int)hex;
    return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
}
