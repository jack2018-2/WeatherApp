using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    /// <summary>
    /// Базовая модель для сущностей в БД
    /// </summary>
    public abstract class BaseModel
    {
        /// <summary>
        /// Id записи
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Дата создания записи
        /// </summary>
        public DateTime? Created { get; set; }
    }
}
