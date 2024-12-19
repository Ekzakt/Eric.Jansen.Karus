using Karus.Application.Dtos;
using Karus.Infrastucture.Models;

namespace Karus.Infrastucture.Mappers;

public static class ModelToDtoMappers
{
    public static OpdrachtItemDto ToOpdrachtItem(this OpdrachtItem opdrachtItem)
    {
        return new OpdrachtItemDto
        {
            Name = opdrachtItem.Name,
            CardImageUri = opdrachtItem.CardImageUri,
            NavigationUri = opdrachtItem.NavigationUri,
            Description = opdrachtItem.Description
        };
    }
}
