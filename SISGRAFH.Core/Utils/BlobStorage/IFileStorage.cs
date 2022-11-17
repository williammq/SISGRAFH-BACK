using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Utils.BlobStorage
{
    public interface IFileStorage
    {
        Task<string> EditFile(byte[] contenido, string extension,
          string nombreContenedor, string rutaArchivo);
        Task DeleteFile(string ruta, string nombreContenedor);
        Task<string> SaveFile(byte[] contenido, string extension,
            string nombreContenedor);
        Task<string> SaveDoc(byte[] contenido, string extension,
            string nombreContenedor);
    }
}
