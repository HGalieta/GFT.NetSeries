using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO_TvShows.Classes
{
    public class TvShow : BaseEntity
    {
        public TvShow(int id, Genre genre, string title, string description, int year)
        {
            Id = id;
            Genre = genre;
            Title = title;
            Description = description;
            Year = year;
            Deleted = false;
        }

        public override string ToString()
        {
            string response = "";
            response += $"Gênero: {Genre}\n";
            response += $"Título: {Title}\n";
            response += $"Descrição: {Description}\n";
            response += $"Lançado em: {Year}\n";
            response += $"Excluido: {Deleted}";

            return response;
        }

        public string ReturnTitle()
        {
            return Title;
        }

        public int ReturnId()
        {
            return Id;
        }

        public bool IsDeleted()
        {
            return Deleted;
        }

        public void Delete()
        {
            Deleted = true;
        }

        private Genre Genre { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private string Title { get; set; }
        private bool Deleted { get; set; }

    }
}
