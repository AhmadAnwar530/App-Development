using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ScreenTemplate
{
    public interface IPhotoPickerService
    {
        Task<Stream> GetImageStreamAsync();
    }

    //A Task represents an asynchronous operation, and Stream is a type that represents a sequence of bytes, often used for reading and writing files.
    //hat should return a Task representing the stream of an image. This interface can be used to create different implementations of the GetImageStreamAsync method for different platforms 
}
