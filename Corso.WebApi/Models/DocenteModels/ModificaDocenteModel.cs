namespace Corso.WebApi.Models.DocenteModels
{
    /// <summary>
    /// Modello utilizzato per modificare un docente esistente.
    /// </summary>
    public class ModificaDocenteModel : CreaDocenteModel
    {
        /// <summary>
        /// Identificativo univoco del docente da modifcare .
        /// </summary>
        public int IDDocente { get; set; }
    }
}
