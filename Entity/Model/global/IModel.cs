using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.global
{
    /// <summary>
    /// Interfaz comun para todos lo modelos de security
    /// </summary>
    public abstract class IModel
    {
        /// <summary>
        /// registro de registro
        /// </summary>
        public DateTime? CreatedAt { get; set; }
        /// <summary>
        /// registro de actualiacion 
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// registro de Eliminacion logica
        /// </summary>
        public DateTime? DeletedAt { get; set; }

        /// <summary>
        /// Estado de eliminado logico
        /// </summary>
        public int Status { get; set; } = 1;

    }
}
