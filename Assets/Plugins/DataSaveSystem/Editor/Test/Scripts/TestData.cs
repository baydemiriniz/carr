using DataSave;

namespace Test
{
	public class TestData :IData
	{
		public int level;
		public int coin;
		public void Init()
		{
			coin = 0;
			level = 0;
		}
	}
}
