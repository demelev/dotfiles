﻿namespace System.Deployment.Internal.Isolation
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    internal struct CATEGORY
    {
        public IDefinitionIdentity DefinitionIdentity;
    }
}

