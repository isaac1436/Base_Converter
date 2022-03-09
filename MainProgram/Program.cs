class MainProgram
{

    static void Main()
    {
        bool errorCatch;//a bool value to validate user input
        Console.WriteLine("This is a program to convert from any base to any other base");
        Console.Write("Please enter the base of the number to be converted : ");

        //Base prime holds the value of the base of the number entered
        errorCatch = int.TryParse(Console.ReadLine(), out int @basePrime);

        Console.Write("\n\nPlease enter the base youd like to convert to : ");

        //base holds the value of the base you're converting to
        errorCatch = int.TryParse(Console.ReadLine(), out int @base);

        //First we rule out hex numbers as they contain letters and will be problematic
        if (@base != 16 && @basePrime != 16)
        {
            Console.Write("\n\nPlease enter the number to be converted : ");
            errorCatch = int.TryParse(Console.ReadLine(), out int num1);

            if (@basePrime == 10)
            {
                dec2AOB(num1, @base);
            }


            else if (@base == 10)
            {
                int result = AOB2dec(num1, @basePrime);
            }

            else
            {
                //So first we convert from base prime to decimal 
                int result = AOB2dec(num1, @basePrime);
                //and then we convert from decimal to the base you want
                dec2AOB(result, @base);
            }

        }

        //this conditional statement serves to convert from base 16
        else if (@basePrime == 16)
        {
            Console.Write("\n\nPlease enter the number to be converted : ");
            string num1 = Console.ReadLine();

            //The method to solve for result is an inbuilt c# method that could also be modified to convert from other bases
            int result = Convert.ToInt32(num1, 16);
            dec2AOB(result, @base);
        }


        //this conditional statement serves to convert to base 16
        else if (@base == 16)
        {
            Console.Write("\n\nPlease enter the number to be converted : ");
            errorCatch = int.TryParse(Console.ReadLine(), out int num1);
            int result = AOB2dec(num1, @basePrime);
            dec2hex(result);
        }
    }

    //Method to convert from any base except base 16, to decimal
    public static int AOB2dec(int num, int @basePrime)
    {
        int decNo = 0;//a variable to hold the decimal number after the operation is done

        int no = num;//a local variable to help split the digits of the number

        int[] digits = new int[32];//an Array to store the split digits

        int count = 0;//serves as an index and also as the length for the digit splitter array

        //The while statement below is the actual digit splitter
        while (no != 0)
        {
            Math.DivRem(no, 10, out digits[count]);//The math.divRem method helps in splitting the digits

            count++;

            no /= 10;//the digit is divided by 10 in every iteration so as to allow you move from right to left
        }

        for (int j = count; j >= 0; j--)
        {
            decNo += (int)(digits[j] * (Math.Pow(@basePrime, j)));//The actual expression to help calculate the decimal value
        }

        return decNo;

    }

    //A method to convert from decimal to any other base
    public static int[] dec2AOB(int num, int @base)
    {
        //below is the digit splitter code snippet as explained in the previous method
        int no = num;
        int[] digits = new int[32];
        int count = 0;

        while (no != 0)
        {
            Math.DivRem(no, @base, out digits[count]);//THis expression serves as the divsion by the base you're converting to, while also taking note of the remainder
            count++;
            no /= @base;
        }

        Console.Write("The number entered in base {0} is ", @base);

        //The for loop below prints out the values in the array in reverse order
        for (int j = count - 1; j >= 0; j--)
        {
            Console.Write(digits[j]);
        }
        return digits;
    }

    //A method to convert from decimal to hexadecimal
    public static int dec2hex(int num)
    {

        string[] hexNum = new string[32];//A string to store the hex Number since most hex numbers contain letters
        int no = num;
        int[] hexNo = new int[32];//an array to store the products of divsion by 16
        int count = 0;

        //The digit splitter snippet
        while (no != 0)
        {
            Math.DivRem(no, 16, out hexNo[count]);

            //A series of conditional statements to decide the value to be passed into our hex number 
            if (hexNo[count] == 10) { hexNum[count] = "A"; }
            else if (hexNo[count] == 11) { hexNum[count] = "B"; }
            else if (hexNo[count] == 12) { hexNum[count] = "C"; }
            else if (hexNo[count] == 13) { hexNum[count] = "D"; }
            else if (hexNo[count] == 14) { hexNum[count] = "E"; }
            else if (hexNo[count] == 15) { hexNum[count] = "F"; }

            else
            {
                hexNum[count] = Convert.ToString(hexNo[count]);//For the range of values 0-9 who hae no alphabetical counterpart
            }

            count++;
            no /= 16;
        }

        Console.Write("The number entered in base {0} is ", 16);
        for (int j = count - 1; j >= 0; j--)
        {
            Console.Write(hexNum[j]);
        }

        return no;
    }
}
