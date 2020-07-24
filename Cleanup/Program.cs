using Microsoft.Win32.SafeHandles;
using System;
using System.IO;

namespace Cleanup
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    internal class DisposableType : IDisposable
    {
        private FileStream _stream;
        private LargeObject _large;
        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                return;
            if (disposing)
            {
                _stream.Dispose();
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            _large = null;
            _disposed = true;
        }

        //FileStream is Finalized by SafeHandle
        // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        //~DisposableType()
        //{
        //    // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //    Dispose(disposing: false);
        //}

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public void DoSomething()
        {
            if (this._disposed)
                throw new ObjectDisposedException(this.ToString());

            Console.WriteLine("This is disposable.");
        }
    }

    internal class DerivedFromDisposableType : DisposableType
    {
        private IntPtr _handle;
        private bool _disposed = false;

        public DerivedFromDisposableType(IntPtr handle)
        {
            _handle = handle;
        }

        protected override void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            CloseHandle(_handle);
            _handle = IntPtr.Zero;

            _disposed = true;
            base.Dispose(disposing);
        }

        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static bool CloseHandle(IntPtr handle);

        ~DerivedFromDisposableType() => Dispose(false);
    }

    class LargeObject
    {

    }


}
