﻿using System.ComponentModel.DataAnnotations;

namespace Corso.WebApi.Models.StudenteModels
{
    /// <summary>
    /// Modello utilizzato per creare uno studente
    /// </summary>
    public class CreaStudenteModel
    {
        /// <summary>
        /// Cognome dello studente .Deve essere compreso fra 1 e 50 caratteri .
        /// </summary>
        [Required, MinLength(1), MaxLength(50)]
        public string Cognome { get; set; } = null!;
        /// <summary>
        /// Nome dello studente . Deve essere compreso fra 1 e 50 caratteri. 
        /// </summary>
        [Required, MinLength(1), MaxLength(50)]
        public string Nome { get; set; } = null!;
        /// <summary>
        /// Matricola dello studente . Deve essere compreso fra 1 e 50 caratteri. 
        /// </summary>
        [Required, MinLength(1), MaxLength(50)]
        public string Matricola { get; set; } = null!;

    }
}
