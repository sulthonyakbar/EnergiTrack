using EnergiTrack.Domain;
using EnergiTrack.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergiTrack.Service
{
    public static  class KategoriStore
    {
        public static CrudService<Category> CategoryStore { get; } = new();
    }
}
