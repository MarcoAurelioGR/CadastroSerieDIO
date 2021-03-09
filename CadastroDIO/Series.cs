using System;

namespace Cadastro_DIO
{
    public class Series : Class1
    {
         
        private Genero sexo { get; set; } 

        private string nomeSerie { get; set; }

        private string Descricao { get; set; }

        private int Ano { get; set; }

        private bool exclui { get; set; }
        public Series(int ID, Genero genero, string titulo, string descricao, int ano) 
        {
            this.ID = ID;
            this.sexo = genero;
            this.nomeSerie = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.exclui = false;
        }

        public override string ToString()
        {
            string retorno = "";

            retorno += "Genero: " + this.sexo + Environment.NewLine;
            retorno += "Titulo: " + this.nomeSerie + Environment.NewLine;
            retorno += "Descricao: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Inicio: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.exclui;

            return retorno;
        }

        public string RetornaTitulo()
        {
            return this.nomeSerie;
        }

        public int RetornaID()
        {
            return this.ID;
        }

        public bool RetornaExcluir()
        {
            return this.exclui;
        }

        public void Excluir()
        {
            this.exclui = true;
        }
    }
}
