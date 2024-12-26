using Karus.Application.Dtos;
using Karus.Domain.Models;

namespace Karus.Infrastucture.Mappers;

public static class ModelToDtoMappers
{
    public static OpdrachtItemDto ToOpdrachtItem(this OpdrachtItem opdrachtItem)
    {
        return new OpdrachtItemDto
        {
            Name = opdrachtItem.Name,
            CardImageFilename = opdrachtItem.CardImageFilename,
            NavigationUri = opdrachtItem.NavigationUri,
            Description = opdrachtItem.Description
        };
    }
}
