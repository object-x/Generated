//------------------------------------------------------------------------------ 
// <auto-generated> 
// This code was generated by LayerCake Generator v3.7.1.
// http://www.layercake-generator.net
// 
// Changes to this file WILL NOT BE LOST if the code is regenerated. 
// </auto-generated> 
//------------------------------------------------------------------------------

namespace VahapYigit.Test.Models
{
	using System;

	using VahapYigit.Test.Core;

	public partial class Translation
	{
		#region [ Initialize Method ]

		/// <summary>
		/// Initialize the object when the instance is created.
		/// </summary>
		protected override void Initialize()
		{
			base.Initialize();

			// Enter your custom code here...
		}

		#endregion

		#region [ Calculated Properties ]



		#endregion

		#region [ Validation Methods ]

		// Enter the 'partial' keywork and press 'SPACE' key to get the partial methods that can be defined...

		#endregion

		#region [ Statics ]

		/// <summary>
		/// Gets the 'None' translation (string.Empty value on each language) - entry not in database -
		/// </summary>
		public static Translation None
		{
			get
			{
				return new Translation { Key = "None", Value = new LanguageCollection(string.Empty) };
			}
		}

		#endregion
	}

	public static class TranslationExtensions
	{
		// Enter your custom extensions methods here...
	}
}