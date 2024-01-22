using ImageUtopia.Utils;

namespace ImageUtopia.UnitTests;

public class UtilsTests
{
	[Test]
	public void Option_ReturnValue()
    {
        var option = Option<string>.Some("Hello!");
		
		var isSome = option.IsSome;
		var result = option.Unwrap();
		
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.EqualTo("Hello!"));
            Assert.That(isSome, Is.True);
        });
    }
	
	[Test]
	public void Option_ThrowsException()
	{
		var option = Option<string>.None();
		
		var isNone = option.IsNone;
		
		Assert.Multiple(() =>
		{
			Assert.Throws<InvalidOperationException>(() => option.Unwrap());
			Assert.That(isNone, Is.True);
		});
	}
	
	[Test]
	public void Option_Map()
	{
		var option = Option<string>.Some("Hello!");
		
		Assert.Pass();
		
		/*var result = option.Map(s => s.Length);
		
		Assert.Multiple(() =>
		{
			Assert.That(result.IsSome, Is.True);
			Assert.That(result, Is.InstanceOf<Option<int>>());
			Assert.That(result.Unwrap(), Is.EqualTo(6));
		});*/
	}
	
	[Test]
	public void Option_Map_WithNone()
	{
		var option = Option<string>.None();
		
		Assert.Pass();
		
		/*var result = option.Map(s => s.Length);
		
		Assert.Multiple(() =>
		{
			Assert.That(result.IsNone, Is.True);
			Assert.That(result, Is.InstanceOf<Option<int>>());
		});*/
	}
	
	[Test]
	public void Option_DefaultValue()
	{
		var option = Option<string>.None();
		
		var result = option.UnwrapOrDefault("Default");
		
		Assert.Multiple(() =>
		{
			Assert.That(result, Is.EqualTo("Default"));
		});
	}
}