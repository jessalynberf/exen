using System;
using System.IO;

public class PEFilePatcher
{
    private readonly BinaryWriter builder;
    private readonly PEDirectoriesBuilder _peDirectoriesBuilder;

    public PEFilePatcher(Stream stream, PEDirectoriesBuilder directoriesBuilder)
    {
        builder = new BinaryWriter(stream);
        _peDirectoriesBuilder = directoriesBuilder;
    }

    public void PatchImportAddressTableRva(int importAddressTableRva)
    {
        // Compute the offset from the entry point to the IAT minus 6 bytes
        int offset = importAddressTableRva - _peDirectoriesBuilder.AddressOfEntryPoint - 6;
        
        // Write this value to the stream or file
        builder.WriteInt32(offset);
    }
}

public class PEDirectoriesBuilder
{
    public int AddressOfEntryPoint { get; set; }
}

// Usage example:
var peDirectoriesBuilder = new PEDirectoriesBuilder { AddressOfEntryPoint = 0x1000 };
using (var stream = new MemoryStream())
{
    var patcher = new PEFilePatcher(stream, peDirectoriesBuilder);
    patcher.PatchImportAddressTableRva(0x2000);
    
    stream.Seek(0, SeekOrigin.Begin);
    Console.WriteLine(BitConverter.ToInt32(stream.ToArray(), 0));  // Outputs: 0xFFF6 or -10
}
