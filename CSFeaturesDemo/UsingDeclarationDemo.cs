using System;
namespace CSFeaturesDemo
{

    public class DisposableResource : IDisposable
    {
        private bool disposedValue;
        public string Value { get; set; } = "disposable-resource";

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
                Console.WriteLine("Disposed");
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~DisposableResource()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
    public static class UsingDeclarationDemo
    {
        public static void Demo()
        {
            Console.WriteLine("UsingDeclaration Demo");
            using var resource = new DisposableResource { Value = "disposable-resource-using-declaration" };
            Console.WriteLine($"Using resource: {resource.Value}");

            using (var resource2 = new DisposableResource { Value = "disposable-resource-using-block" })
            {
                Console.WriteLine($"Using resource: {resource2.Value}");
            }
            Console.WriteLine("All finished!");
        }
    }
}
