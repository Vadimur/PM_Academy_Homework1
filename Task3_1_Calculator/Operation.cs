using System;

namespace Task3_1_Calculator
{
    [Flags]
    public enum Operation
    {
        Add = 1,
        Subtract = 2,
        Multiply = 4,
        Divide = 8,
        GetDivisionRemainder = 16,
        Pow = 32,
        And = 64,
        Or = 128,
        Xor = 256,
        Not = 512,
        Factorial = 1024,
        
        Unary = Not | Factorial,
        Binary = Add | Subtract | Multiply | Divide | GetDivisionRemainder | Pow,
        BinaryBit = And | Or | Xor
    }
}