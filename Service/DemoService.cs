
namespace AWDataService
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Web;

    [ServiceBehavior(Name = "AWDataService", Namespace = "http://samples.microsoft.com/ServiceModel/Relay/")]
    class DemoService : IDemoContract
    {
        const string imageFileName = "image.jpg";
        Image bitmap;

        public DemoService() 
        {
            this.bitmap = Image.FromFile(imageFileName);
        }

 
        public Stream GetImage()
        {
            MemoryStream stream = new MemoryStream();
            this.bitmap.Save(stream, ImageFormat.Jpeg);

            stream.Position = 0;
            WebOperationContext.Current.OutgoingResponse.ContentType = "image/jpeg";

            return stream;
        }

        private AdventureWorksDataContext db = new AdventureWorksDataContext();
        public Product GetProduct(string id)
        {
            Product product = db.GetTenantById(id);
            return product;

        }

    }
}
