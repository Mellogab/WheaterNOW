﻿using System.ComponentModel.DataAnnotations;

namespace WheaterAPI.Model
{
    public class MonitorCity 
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Por Favor, Preencha o campo Cidade")]
        public string CitySearched { get; set; }
        [Required(ErrorMessage ="Algo errado ocorreu, tenta novamento mais tarde !!")]
        public int IdUser { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
