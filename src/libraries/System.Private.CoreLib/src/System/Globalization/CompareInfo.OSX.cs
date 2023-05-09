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
            string cultureName = m_name;

            // GetReference may return nullptr if the input span is defaulted. The native layer handles
            // this appropriately; no workaround is needed on the managed side.

            fixed (char* pString1 = &MemoryMarshal.GetReference(string1))
            fixed (char* pString2 = &MemoryMarshal.GetReference(string2))
            {
                System.Diagnostics.Debug.Write("Collation CompareStringNative is called for culture: " + cultureName + "string1: " + string1.ToString() + "string2: " + string2.ToString() + "\n");
                var result = Interop.Globalization.CompareStringNative(cultureName, pString1, string1.Length, pString2, string2.Length, options);
                System.Diagnostics.Debug.Write("Collation CompareStringNative result: " + result + "\n");
                return result;
            }
        }
    }
}
