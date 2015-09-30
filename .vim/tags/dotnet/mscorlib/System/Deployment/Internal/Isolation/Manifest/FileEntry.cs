﻿namespace System.Deployment.Internal.Isolation.Manifest
{
    using System;
    using System.Deployment.Internal.Isolation;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    internal class FileEntry : IDisposable
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string Name;
        public uint HashAlgorithm;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string LoadFrom;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string SourcePath;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string ImportPath;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string SourceName;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string Location;
        [MarshalAs(UnmanagedType.SysInt)]
        public IntPtr HashValue;
        public uint HashValueSize;
        public ulong Size;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string Group;
        public uint Flags;
        public MuiResourceMapEntry MuiMapping;
        public uint WritableType;
        public ISection HashElements;
        ~FileEntry()
        {
            this.Dispose(false);
        }

        void IDisposable.Dispose()
        {
            this.Dispose(true);
        }

        public void Dispose(bool fDisposing)
        {
            if (this.HashValue != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(this.HashValue);
                this.HashValue = IntPtr.Zero;
            }
            if (fDisposing)
            {
                if (this.MuiMapping != null)
                {
                    this.MuiMapping.Dispose(true);
                    this.MuiMapping = null;
                }
                GC.SuppressFinalize(this);
            }
        }
    }
}

