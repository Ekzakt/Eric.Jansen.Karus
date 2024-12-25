using Karus.Application.Dtos;
using Karus.Domain.Models;

namespace Karus.Application.Mappers;

public static class MapperExtensions
{
    public static QuoteDto ToDto(this Quote quote)
    {
        return new QuoteDto
        {
            Id = quote.Id,
            Text = quote.Text,
            Author = quote.Author,
            QuoteYear = quote.QuoteYear,
            Location = quote.Location,
            Category = quote.Category
        };
    }

    public static Quote ToModel(this QuoteDto quoteDto)
    {
        return new Quote
        {
            Id = quoteDto.Id,
            Text = quoteDto.Text,
            Author = quoteDto.Author,
            QuoteYear = quoteDto.QuoteYear,
            Location = quoteDto.Location,
            Category = quoteDto.Category
        };
    }
}
