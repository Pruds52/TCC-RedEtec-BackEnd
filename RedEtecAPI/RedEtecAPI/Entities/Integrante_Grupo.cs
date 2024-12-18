﻿namespace RedEtecAPI.Entities
{
    public class Integrante_Grupo
    {
        public int Id_Integrante_Grupo { get; set; }
        public int Id_Grupo { get; set; }
        public int Id_Usuario { get; set; }
        public DateTime Data_Entrada { get; set; }
        public int Deletado_Integrante_Grupo { get; set; }
        public virtual Grupo Grupo { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
