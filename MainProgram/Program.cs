class MainProgram
{

    static void Main()
    {
        Console.WriteLine("This is a program to convert from any base to any other base");
        Console.Write("Please enter the base of the number to be converted : ");
        int @basePrime = int.Parse(Console.ReadLine());

        Console.Write("\n\nPlease enter the base youd like to convert to : ");
        int @base = int.Parse(Console.ReadLine());

        Console.Write("\n\nPlease enter the number to be converted : ");
        int dec1 = int.Parse(Console.ReadLine());

        int result = AOB2dec(dec1, @basePrime);

        dec2AOB(result, @base);
    }

    public static int AOB2dec(int num, int @basePrime)
    {
        int decNo = 0;
        int no = num;
        int[] digits = new int[32];
        int i = 0;
        int count = 0;

        while (no != 0)
        {
            Math.DivRem(no, 10, out digits[i]);
            i++;
            count++;
            no /= 10;
        }

        for (int j = count; j >= 0; j--)
        {
            decNo += (int)(digits[j] * (Math.Pow(@basePrime, j)));
        }

        return decNo;

    }

    public static int[] dec2AOB(int num, int @base)
    {
        int no = num;
        int[] digits = new int[32];
        int i = 0;
        int count = 0;

        while (no != 0)
        {
            Math.DivRem(no, @base, out digits[i]);
            i++;
            count++;
            no /= @base;
        }

        Console.Write("The number entered in base {0} is ", @base);
        for (int j = count - 1; j >= 0; j--)
        {
            Console.Write(digits[j]);
        }
        return digits;
    }
}
