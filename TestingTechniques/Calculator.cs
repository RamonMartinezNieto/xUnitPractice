namespace TestingTechniques;

public class Calculator
{

    public static int Add (int firstNumber, int secondNumber)
        => firstNumber + secondNumber;

    public static int Subtract(int firstNumber, int secondNumber)
        => firstNumber - secondNumber;

    public static int Multiply(int firstNumber, int secondNumber)
        => firstNumber * secondNumber;

    public static int Divide(int firstNumber, int secondNumber)
    {
        EnsureThatDivisorIsNotZero(secondNumber);

        return firstNumber / secondNumber;
    }

    private static void EnsureThatDivisorIsNotZero(int secondNumber)
    {
        if(secondNumber == 0)
            throw new DivideByZeroException("Attempted to divide by zero.");
    }
}