// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
using System;
using System.Globalization;
/// <summary>
/// Int64.System.IConvertible.ToUInt64()
/// </summary>
public class Int64IConvertibleToUInt64
{
    public static int Main()
    {
        Int64IConvertibleToUInt64 ui64IContUInt64 = new Int64IConvertibleToUInt64();
        TestLibrary.TestFramework.BeginTestCase("Int64IConvertibleToUInt64");
        if (ui64IContUInt64.RunTests())
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("PASS");
            return 100;
        }
        else
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("FAIL");
            return 0;
        }
    }
    public bool RunTests()
    {
        bool retVal = true;
        TestLibrary.TestFramework.LogInformation("[PosTest]");
        retVal = PosTest1() && retVal;
        retVal = PosTest2() && retVal;
        retVal = PosTest3() && retVal;
        TestLibrary.TestFramework.LogInformation("[NegTest]");
        retVal = NegTest1() && retVal;
        retVal = NegTest2() && retVal;
        return retVal;
    }
    #region PositiveTest
    public bool PosTest1()
    {
        bool retVal = true;
        CultureInfo myculture = new CultureInfo("en-us");
        IFormatProvider provider = myculture.NumberFormat;
        TestLibrary.TestFramework.BeginScenario("PosTest1:Int64 MaxValue IConvertible To UInt64");
        try
        {
            long int64A = Int64.MaxValue;
            IConvertible iConvert = (IConvertible)(int64A);
            ulong uint64A = iConvert.ToUInt64(provider);
            if ((long)uint64A != int64A)
            {
                TestLibrary.TestFramework.LogError("001", "the ActualResult is not the ExpectResult");
                retVal = false;
            }
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("002", "Unexpected exception: " + e);
            retVal = false;
        }
        return retVal;
    }
    public bool PosTest2()
    {
        bool retVal = true;
        CultureInfo myculture = new CultureInfo("en-us");
        IFormatProvider provider = myculture.NumberFormat;
        TestLibrary.TestFramework.BeginScenario("PosTest2:Random Int64 IConvertible To UInt64 1");
        try
        {
            long int64A = TestLibrary.Generator.GetInt64(-55);
            IConvertible iConvert = (IConvertible)(int64A);
            ulong uint64A = iConvert.ToUInt64(provider);
            if ((long)uint64A != int64A)
            {
                TestLibrary.TestFramework.LogError("003", "the ActualResult is not the ExpectResult");
                retVal = false;
            }
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("004", "Unexpected exception: " + e);
            retVal = false;
        }
        return retVal;
    }
    public bool PosTest3()
    {
        bool retVal = true;
        CultureInfo myculture = new CultureInfo("el-GR");
        IFormatProvider provider = myculture.NumberFormat;
        TestLibrary.TestFramework.BeginScenario("PosTest3:Random Int64 IConvertible To UInt64 2");
        try
        {
            long int64A = TestLibrary.Generator.GetInt64(-55);
            IConvertible iConvert = (IConvertible)(int64A);
            ulong uint64A = iConvert.ToUInt64(provider);
            if ((long)uint64A != int64A)
            {
                TestLibrary.TestFramework.LogError("005", "the ActualResult is not the ExpectResult");
                retVal = false;
            }
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("006", "Unexpected exception: " + e);
            retVal = false;
        }
        return retVal;
    }
    #endregion
    #region NegativeTest
    public bool NegTest1()
    {
        bool retVal = true;
        CultureInfo myculture = new CultureInfo("en-us");
        IFormatProvider provider = myculture.NumberFormat;
        TestLibrary.TestFramework.BeginScenario("NegTest1: The current Int64 value is out of UInt64 range 1");
        try
        {
            long int64A = Int64.MinValue;
            IConvertible iConvert = (IConvertible)(int64A);
            ulong uint64 = iConvert.ToUInt64(provider);
            retVal = false;
            TestLibrary.TestFramework.LogError("N001", "The current Int64 value is out of UInt64 range but not throw exception");
        }
        catch (OverflowException) { }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("N002", "Unexpected exception: " + e);
            retVal = false;
        }
        return retVal;
    }
    public bool NegTest2()
    {
        bool retVal = true;
        TestLibrary.TestFramework.BeginScenario("NegTest2: The current Int64 value is out of UInt64 range 2");
        try
        {
            long int64A = (TestLibrary.Generator.GetInt64(-55) + 1) * (-1);
            IConvertible iConvert = (IConvertible)(int64A);
            ulong uint64 = iConvert.ToUInt64(null);
            retVal = false;
            TestLibrary.TestFramework.LogError("N003", "The current Int64 value is out of UInt64 range but not throw exception");
        }
        catch (OverflowException) { }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("N004", "Unexpected exception: " + e);
            retVal = false;
        }
        return retVal;
    }
    #endregion
}
