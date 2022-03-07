class Exercise10
{
    static void Main()
    {
        Console.WriteLine("This is a program to convert from binary to decimal using the Horner Scheme");
        Console.Write("Please enter the Binary Number to be converted: ");
        int binaryNum=int.Parse(Console.ReadLine());
        Console.WriteLine("The number in decimal is " + Bin2dec(binaryNum));
    }

    public static int Bin2dec(int num)
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

        for (int j = count; j > 0; j--)
        {
            decNo += (int)(digits[j]);
            decNo *= 2;
        }
        if (digits[0] == 1)
        {
            decNo++;
        }
        return decNo;
    }
}