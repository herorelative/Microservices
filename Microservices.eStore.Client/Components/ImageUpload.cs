using Microservices.eStore.Client.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Tewr.Blazor.FileReader;

namespace Microservices.eStore.Client.Components
{
    public partial class ImageUpload : ComponentBase
    {
        [Parameter]
        public string ImageUrl { get; set; }

        [Parameter]
        public EventCallback<string> OnChange { get; set; }

        private ElementReference _input;

        [Inject]
        public IEVoucherService _Repo { get; set; }

        [Inject]
        public IFileReaderService _FileReader { get; set; }

        private async Task HandleChanged()
        {
            foreach (var file in await _FileReader.CreateReference(_input).EnumerateFilesAsync())
            {
                if (file != null)
                {
                    var fileInfo = await file.ReadFileInfoAsync();
                    using var ms = await file.CreateMemoryStreamAsync(4 * 1024);
                    var content = new MultipartFormDataContent();
                    content.Headers.ContentDisposition = 
                        new ContentDispositionHeaderValue("form-data");
                    content.Add(new StreamContent(
                            ms, 
                            Convert.ToInt32(ms.Length)), 
                            "image", 
                            fileInfo.Name);
                    ImageUrl = await _Repo.UploadEvoucherImage(content);
                    await OnChange.InvokeAsync(ImageUrl);
                }
            }
        }
    }
}
