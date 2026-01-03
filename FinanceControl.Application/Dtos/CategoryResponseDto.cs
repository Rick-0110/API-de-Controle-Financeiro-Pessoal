using System.ComponentModel.DataAnnotations;

namespace FinanceControl.Application.Dtos
{
    public class CategoryResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Description { get; set; }
        public int UserId { get; set; }


    }

}
