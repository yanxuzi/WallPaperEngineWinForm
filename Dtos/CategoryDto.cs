namespace WallPaperEngineWinForm.Dtos;

public class CategoryDto
{
    public int Id { get; set; }

    public string Text { get; set; }

    public string TypeCode { get; set; }

    public int ParentId { get; set; }

    //public List<CategoryDto> Children { get; set; }
}