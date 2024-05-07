namespace CarBook.Application.Features.ContactFeature.DTOs;

public class ContactGetByIdDto
    {
    public int Id { get; set; }
    public string Name { get; set; }

    public string Email { get; set; }

    public string Subject { get; set; }

    public string Message { get; set; }

    public DateTime CreatedDate { get; set; }
    }