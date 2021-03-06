// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

/*============================================================
**
** Class:  SafeTokenHandle 
**
** A wrapper for a process handle
**
** 
===========================================================*/

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;

namespace Microsoft.Win32.SafeHandles
{
    [SecurityCritical]
    internal sealed partial class SafeTokenHandle : SafeHandle
    {
        internal static readonly SafeTokenHandle InvalidHandle = new SafeTokenHandle(new IntPtr(DefaultInvalidHandleValue));

        internal SafeTokenHandle() : base(new IntPtr(DefaultInvalidHandleValue), true) { }

        internal SafeTokenHandle(IntPtr handle)
            : base(new IntPtr(DefaultInvalidHandleValue), true)
        {
            SetHandle(handle);
        }

        public SafeTokenHandle(IntPtr handle, bool ownsHandle)
            : base(new IntPtr(DefaultInvalidHandleValue), ownsHandle)
        {
            SetHandle(handle);
        }

        internal void InitialSetHandle(IntPtr h)
        {
            Debug.Assert(IsInvalid, "Safe handle should only be set once");
            base.handle = h;
        }
    }
}
