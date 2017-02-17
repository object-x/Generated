//------------------------------------------------------------------------------ 
// <auto-generated> 
// This code was generated by LayerCake Generator v3.7.1.
// http://www.layercake-generator.net
// 
// Changes to this file WILL NOT BE LOST if the code is regenerated. 
// </auto-generated> 
//------------------------------------------------------------------------------

namespace VahapYigit.Test.Business
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.ServiceModel;
	using System.Transactions;

	using VahapYigit.Test.Business;
	using VahapYigit.Test.Core;
	using VahapYigit.Test.Crud;
	using VahapYigit.Test.Models;

	[BusinessClass]
	public class TranslationBusiness : BusinessBase
	{
		#region [ Members ]

		private static ICacheService _innerCacheService = null;
		private static readonly object _innerLocker = new object();

		#endregion

		#region [ Constructors ]

		static TranslationBusiness()
		{
			CreateCache();
		}

		#endregion

		#region [ Custom public methods ]

		/// <summary>
		/// Resolves translation object from a key (uses inner cache to store retrieved translations).
		/// </summary>
		/// 
		/// <param name="userContext">
		/// User context.
		/// </param>
		/// 
		/// <param name="translationKey">
		/// Translation key.
		/// </param>
		/// 
		/// <returns>
		/// The Translation object.
		/// </returns>
		[BusinessMethod]
		public Translation Resolve(IUserContext userContext, TranslationEnum translationKey)
		{
			if (translationKey == TranslationEnum.None) // special case
			{
				return Translation.None;
			}

			using (var et = new ExecutionTracerService())
			{
				string key = translationKey.ToString();

				var translation = this.GetFromCache(key);
				if (translation == null)
				{
					lock (_innerLocker)
					{
						translation = this.GetFromCache(key);
						if (translation == null)
						{
							var options = new SearchOptions();

							options.Filters.Add(Translation.ColumnNames.Key, FilterOperator.Equals, key);
							options.MaxRecords = 1;

							using (var db = new TranslationCrud(userContext))
							{
								translation = db.Search(ref options).FirstOrDefault();
							}

							if (translation != null)
							{
								_innerCacheService.Add(new CacheItem { Key = key, Data = translation });
							}
						}
					}
				}

				return translation;
			}
		}

		/// <summary>
		/// Resolves translation message from a key (uses inner cache to store retrieved translations).
		/// </summary>
		/// 
		/// <param name="userContext">
		/// User context.
		/// </param>
		/// 
		/// <param name="translationKey">
		/// Translation key.
		/// </param>
		/// 
		/// <param name="culture">
		/// Culture (VahapYigit.Test.Core.Cultures class).
		/// </param>
		/// 
		/// <param name="args">
		/// Optional arguments to format the message.
		/// </param>
		/// 
		/// <returns>
		/// The Translation message.
		/// </returns>
		[BusinessMethod]
		public string GetMessage(IUserContext userContext, TranslationEnum translationKey, string culture, params object[] args)
		{
			string message = "N.C.";

			if (!Cultures.IsSupported(culture))
			{
				culture = Cultures.Default;
			}

			var translation = this.Resolve(userContext, translationKey);
			if (translation != null)
			{
				message = translation.Value[culture];

				if (!args.IsNullOrEmpty() && message != null)
				{
					message = string.Format(message, args);
				}
			}

			return message;
		}

		/// <summary>
		/// Resolves translation message from a key (uses inner cache to store retrieved translations).
		/// </summary>
		/// 
		/// <param name="userContext">
		/// User context.
		/// </param>
		/// 
		/// <param name="translationKey">
		/// Translation key.
		/// </param>
		/// 
		/// <param name="args">
		/// Optional arguments to format the message.
		/// </param>
		/// 
		/// <returns>
		/// The Translation message.
		/// </returns>
		[BusinessMethod]
		[OperationContract(Name = "GetMessageWithUserCulture")]
		public string GetMessage(IUserContext userContext, TranslationEnum translationKey, params object[] args)
		{
			return this.GetMessage(userContext, translationKey, userContext.Culture, args);
		}

		#endregion

		#region [ Custom private methods ]

		/// <summary>
		/// Resolves translation object from a key from the inner cache if the entry exists.
		/// </summary>
		/// 
		/// <param name="key">
		/// Cache key.
		/// </param>
		/// 
		/// <returns>
		/// The translation if exists; otherwise, null.
		/// </returns>
		private Translation GetFromCache(string key)
		{
			return _innerCacheService.Get<Translation>(key);
		}

		/// <summary>
		/// Remove all the Translations instances from the inner cache.
		/// </summary>
		public void PurgeTranslationCache()
		{
			ReleaseCache();
			CreateCache();
		}

		/// <summary>
		/// Creates the inner cache.
		/// </summary>
		private static void CreateCache()
		{
			ReleaseCache();

			if (_innerCacheService == null)
			{
				lock (_innerLocker)
				{
					if (_innerCacheService == null)
					{
						_innerCacheService = new LocalMemoryCacheService(); // inner cache
					}
				}
			}
		}

		/// <summary>
		/// Releases the inner cache from memory.
		/// </summary>
		private static void ReleaseCache()
		{
			if (_innerCacheService != null)
			{
				lock (_innerLocker)
				{
					if (_innerCacheService != null)
					{
						_innerCacheService.SafeDispose();
						_innerCacheService = null;
					}
				}
			}
		}

		#endregion
	}
}