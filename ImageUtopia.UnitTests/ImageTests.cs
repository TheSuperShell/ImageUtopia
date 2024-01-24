using ImageUtopia.Models;
using Object = ImageUtopia.Models.Object;

namespace ImageUtopia.UnitTests;

public class ImageTests
{
	[Test]
	public void ImageMetadataTest()
    {
	    string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestImages", "unnamed.jpg");
	    TestContext.WriteLine(path);
	    
        var objectBuilder = new ObjectBuilder(path);
		var result = objectBuilder.Init().Build();
		Assert.That(result.IsOk, Is.True);
		
		Object image = result.Unwrap();
        Assert.Multiple(() =>
        {
            Assert.That(image.Name, Is.EqualTo("unnamed.jpg"));
            Assert.That(image.Extension, Is.EqualTo(".jpg"));
            Assert.That(image.Size, Is.EqualTo(40545));
            Assert.That(image.IsImage, Is.True);
            Assert.That(image.Dimensions, Is.EqualTo((640, 640)));
        });
    }

	[Test]
	public void ImageBuilderErrorsTest() {
		var objectBuilder = new ObjectBuilder("nonexistent.jpg");
		var result = objectBuilder.Init().Build();
		
		Assert.Multiple(() => {
			Assert.That(result.IsErr, Is.True);
			Assert.That(result.UnwrapErr().Message, Is.EqualTo("File not found"));
		});
	}
}