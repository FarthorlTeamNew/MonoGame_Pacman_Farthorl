namespace Pacman.JsonConverter.ViewModels
{
    using System.Text;

    public class TopPlayerDto
    {
        public int Place { get; set; }

        public string PlayerName { get; set; }

        public int EatenPoints { get; set; }

        public int EasyLevelsCompleted { get; set; }

        public int TimesDied { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.Place}. ");
            sb.AppendLine($"{this.PlayerName} ");
            sb.AppendLine("Player statistics:");
            sb.AppendLine($"Eaten points - {this.EatenPoints}");
            sb.AppendLine($"Easy levels completed - {this.EasyLevelsCompleted}");
            sb.AppendLine($"Times died - {this.TimesDied}");

            return sb.ToString();
        }
    }
}