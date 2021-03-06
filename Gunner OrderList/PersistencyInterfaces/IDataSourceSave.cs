﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistency.Interfaces
{
    public interface IDataSourceSave<TDTO>
    {
        /// <summary>
        /// Save the given List of objects to the source
        /// </summary>
        /// <param name="objects">
        /// List of objects to save
        /// </param>
        Task Save(List<TDTO> objects);
    }
}