using System;

/* File explanation: These are minimum decompiled classes from Boo.Lang, since Unity no longer has the
 Boo interpreter.*/
public class RuntimeServices
{
    public static Array AddArrays(Type resultingElementType, Array lhs, Array rhs)
    {
        int length = lhs.Length + rhs.Length;
        Array array = Array.CreateInstance(resultingElementType, length);
        Array.Copy(lhs, 0, array, 0, lhs.Length);
        Array.Copy(rhs, 0, array, lhs.Length, rhs.Length);
        return array;
    }
    public static bool EqualityOperator(object lhs, object rhs)
    {
        if (lhs == rhs) return true;

        // Some types do overload Equals to compare
        // against null values
        if (null == lhs) return rhs.Equals(lhs);
        if (null == rhs) return lhs.Equals(rhs);

        TypeCode lhsTypeCode = Type.GetTypeCode(lhs.GetType());
        TypeCode rhsTypeCode = Type.GetTypeCode(rhs.GetType());
        if (IsNumeric(lhsTypeCode) && IsNumeric(rhsTypeCode))
        {
            return EqualityOperator(lhs, lhsTypeCode, rhs, rhsTypeCode);
        }

        Array lhsa = lhs as Array;
        if (null != lhsa)
        {
            Array rhsa = rhs as Array;
            if (null != rhsa)
            {
                return ArrayEqualityImpl(lhsa, rhsa);
            }
        }
        return lhs.Equals(rhs) || rhs.Equals(lhs);
    }
    
    private static bool ArrayEqualityImpl(Array lhs, Array rhs)
    {
        if (lhs.Rank != 1 || rhs.Rank != 1)
        {
            throw new ArgumentException("array rank must be 1");
        }
        if (lhs.Length != rhs.Length)
        {
            return false;
        }
        for (int i = 0; i < lhs.Length; i++)
        {
            if (!EqualityOperator(lhs.GetValue(i), rhs.GetValue(i)))
            {
                return false;
            }
        }
        return true;
    }
    
    private static bool EqualityOperator(object lhs, TypeCode lhsTypeCode, object rhs, TypeCode rhsTypeCode)
    {
        IConvertible convertible = (IConvertible)lhs;
        IConvertible convertible2 = (IConvertible)rhs;
        switch (GetConvertTypeCode(lhsTypeCode, rhsTypeCode))
        {
            case TypeCode.Decimal:
                return convertible.ToDecimal(null) == convertible2.ToDecimal(null);
            case TypeCode.Double:
                return convertible.ToDouble(null) == convertible2.ToDouble(null);
            case TypeCode.Single:
                return convertible.ToSingle(null) == convertible2.ToSingle(null);
            case TypeCode.UInt64:
                return convertible.ToUInt64(null) == convertible2.ToUInt64(null);
            case TypeCode.Int64:
                return convertible.ToInt64(null) == convertible2.ToInt64(null);
            case TypeCode.UInt32:
                return convertible.ToUInt32(null) == convertible2.ToUInt32(null);
            default:
                return convertible.ToInt32(null) == convertible2.ToInt32(null);
        }
    }
    private static TypeCode GetConvertTypeCode(TypeCode lhsTypeCode, TypeCode rhsTypeCode)
    {
        if (lhsTypeCode == TypeCode.Decimal || rhsTypeCode == TypeCode.Decimal)
        {
            return TypeCode.Decimal;
        }
        if (lhsTypeCode == TypeCode.Double || rhsTypeCode == TypeCode.Double)
        {
            return TypeCode.Double;
        }
        if (lhsTypeCode == TypeCode.Single || rhsTypeCode == TypeCode.Single)
        {
            return TypeCode.Single;
        }
        if (lhsTypeCode == TypeCode.UInt64)
        {
            if (rhsTypeCode == TypeCode.SByte || rhsTypeCode == TypeCode.Int16 || rhsTypeCode == TypeCode.Int32 || rhsTypeCode == TypeCode.Int64)
            {
                return TypeCode.Int64;
            }
            return TypeCode.UInt64;
        }
        if (rhsTypeCode == TypeCode.UInt64)
        {
            if (lhsTypeCode == TypeCode.SByte || lhsTypeCode == TypeCode.Int16 || lhsTypeCode == TypeCode.Int32 || lhsTypeCode == TypeCode.Int64)
            {
                return TypeCode.Int64;
            }
            return TypeCode.UInt64;
        }
        if (lhsTypeCode == TypeCode.Int64 || rhsTypeCode == TypeCode.Int64)
        {
            return TypeCode.Int64;
        }
        if (lhsTypeCode == TypeCode.UInt32)
        {
            if (rhsTypeCode == TypeCode.SByte || rhsTypeCode == TypeCode.Int16 || rhsTypeCode == TypeCode.Int32)
            {
                return TypeCode.Int64;
            }
            return TypeCode.UInt32;
        }
        if (rhsTypeCode == TypeCode.UInt32)
        {
            if (lhsTypeCode == TypeCode.SByte || lhsTypeCode == TypeCode.Int16 || lhsTypeCode == TypeCode.Int32)
            {
                return TypeCode.Int64;
            }
            return TypeCode.UInt32;
        }
        return TypeCode.Int32;
    }
    private static bool IsNumeric(TypeCode code)
    {
        switch (code)
        {
            case TypeCode.Byte:
                return true;
            case TypeCode.SByte:
                return true;
            case TypeCode.Int16:
                return true;
            case TypeCode.Int32:
                return true;
            case TypeCode.Int64:
                return true;
            case TypeCode.UInt16:
                return true;
            case TypeCode.UInt32:
                return true;
            case TypeCode.UInt64:
                return true;
            case TypeCode.Single:
                return true;
            case TypeCode.Double:
                return true;
            case TypeCode.Decimal:
                return true;
            default:
                return false;
        }
    }
}
