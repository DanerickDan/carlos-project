using System.Reflection;
using System.Runtime.Loader;

namespace BusinessLayer.InvoiceManagment
{
    public class CustomAssemblyLoadContext : AssemblyLoadContext
    {
        public IntPtr LoadUnmanagedLibrary(string absolutePath)
        {
            return LoadUnmanagedDll(absolutePath);
        }

        protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
        {
            return LoadUnmanagedDllFromPath(unmanagedDllName);
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            return null; // Devuelve null porque no necesitas cargar ningún ensamblado adicional en este caso.
        }
    }
}
