// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Globalization
{
    public partial class CompareInfo
    {
        private unsafe int CompareStringNative(ReadOnlySpan<char> string1, ReadOnlySpan<char> string2, CompareOptions options)
        {
            Debug.Assert(!GlobalizationMode.Invariant);
            Debug.Assert(!GlobalizationMode.UseNls);
            Debug.Assert((options & (CompareOptions.Ordinal | CompareOptions.OrdinalIgnoreCase)) == 0);

            AssertComparisonSupported(options);

            // GetReference may return nullptr if the input span is defaulted. The native layer handles
            // this appropriately; no workaround is needed on the managed side.
            int result;
            fixed (char* pString1 = &MemoryMarshal.GetReference(string1))
            fixed (char* pString2 = &MemoryMarshal.GetReference(string2))
            {
                result = Interop.Globalization.CompareStringNative(m_name, m_name.Length, pString1, string1.Length, pString2, string2.Length, options);
            }

            if (result == -2)
            {
                throw new PlatformNotSupportedException(GetPNSE(options));
            }

            return result;
        }

        private static void AssertComparisonSupported(CompareOptions options)
        {
            if (CompareOptionsNotSupported(options))
                throw new PlatformNotSupportedException(GetPNSE(options));
        }

        private static bool CompareOptionsNotSupported(CompareOptions options) =>
            (options & CompareOptions.IgnoreSymbols) == CompareOptions.IgnoreSymbols ||
            (options & CompareOptions.IgnoreKanaType) == CompareOptions.IgnoreKanaType;

        private static string GetPNSE(CompareOptions options) =>
            SR.Format(SR.PlatformNotSupported_HybridGlobalizationWithCompareOptions, options);
    }
}
