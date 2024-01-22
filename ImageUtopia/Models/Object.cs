namespace ImageUtopia.Models;

public record Object(string Name, string Path, string Extension,  ulong Size, bool IsImage, (uint, uint) Dimensions);