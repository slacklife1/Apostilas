namespace WebSites
{
	using System;
	using System.Collections;

	/// <summary>
	///    Describes a single web site.
	/// </summary>
	/// <remarks>This class has the following members:
	///    <para>Constructors:
	///       <list>
	///          <item>Default Constructor<see cref="WebSite()"/></item>
	///          <item>Single Parameter Constructor<see cref="WebSite(string)"/></item>
	///          <item>Double Parameter Constructor<see cref="WebSite(string, string)"/></item>
	///          <item>Triple Parameter Constructor<see cref="WebSite(string, string, string)"/></item>
	///       </list>
	///    </para>
	///    <para> Methods:
	///       <list>
	///          <item>ValidateUrl<see cref="ValidateUrl"/></item>
	///          <item>ToString<see cref="ToString"/></item>
	///          <item>Equals<see cref="Equals"/></item>
	///          <item>GetHashCode<see cref="GetHashCode"/></item>
	///       </list>
	///    </para>
	///    <para>Properties:
	///       <list>
	///          <item>SiteName<see cref="SiteName"/></item>
	///          <item>URL<see cref="URL"/></item>
	///          <item>Description<see cref="Description"/></item>
	///       </list>
	///    </para>
	/// </remarks>
	public class WebSite 
	{

		const string http      = "http://";
	
		public static readonly string currentDate = new DateTime().ToString();
	
		string siteName;
		string url;
		string description;
	
		// Constructors
	
		/// <summary>
		/// Default Constructor
		/// </summary>
		/// <remarks>
		/// Invokes another constructor with 3 default parameters
		/// </remarks>
		public WebSite() 
			: this("No Site", "no.url", "No Description") {}
		
		/// <summary>
		/// Single String Constructor
		/// </summary>
		/// <remarks>
		/// Invokes another constructor with 3 default parameters
		/// </remarks>
		public WebSite(string newSite) 
			: this(newSite, "no.url", "No Description") {}
		
		/// <summary>
		/// Double String Constructor
		/// </summary>
		/// <remarks>
		/// Invokes another constructor with 3 default parameters
		/// </remarks>
		public WebSite(string newSite, string newURL) 
			: this(newSite, newURL, "No Description") {}
	
		/// <summary>
		/// Three String Constructor
		/// </summary>
		/// <remarks>
		/// Provides full support for WebSite object initialization
		/// </remarks>
		public WebSite(string newSite, string newURL, string newDesc) 
		{
			SiteName    = newSite;
			URL         = newURL;
			Description = newDesc;
		}
	
		// Object functions
	
		/// <summary>
		/// Generates String Representation of Web Site
		/// </summary>
		/// <remarks>
		/// Creates a SiteName, URL, and Description comma
		/// separated string.  Overrides Object.ToString()
		/// </remarks>
		/// <returns>
		/// <para>Comma separated string</para>
		/// </returns>
		public override string ToString() 
		{
			return siteName + ", " + url + ", " + description;
		}
	
		/// <summary>
		/// Compares two Web Sites for equality
		/// </summary>
		/// <remarks>
		/// Overrides Object.Equals() by comparing
		/// <paramref name="evalString"/> to this site.
		/// </remarks>
		/// <param name="evalString">
		/// Value compared against this object.
		/// </param>
		/// <returns>
		///    <list>
		///       <item> true:  Sites are equal.</item>
		///       <item>false:  Sites are not equal.</item>
		///    </list>
		/// </returns>
		public override bool Equals(object evalString) 
		{
			return this.ToString() == evalString.ToString();
		}
	
		/// <summary>
		/// Gets a Hash Code
		/// </summary>
		/// <remarks>
		/// Overrides Object.GetHashCode();
		/// </remarks>
		/// <returns>
		///    <para>integer hash code.</para>
		/// </returns>
		public override int GetHashCode() 
		{
			return this.ToString().GetHashCode();
		}
	
		/// <summary>
		/// Checks URL prefix
		/// </summary>
		/// <remarks>
		/// "http://" prefix prepended when absent.
		/// </remarks>
		/// <param name="url">
		/// URL to check.
		/// </param>
		/// <returns>
		///    <para>String with "http://" prefix.</para>
		/// </returns>
		protected string ValidateUrl(string url) 
		{
			if (!(url.StartsWith(http))) 
			{
				return http + url;
			}
			
			return url;
		}
	
		// Properties
	
		/// <value>
		/// Sets and gets Web Site Name.
		/// </value>
		/// <remarks>
		/// Sets and gets the value of <see cref="siteName"/> field.
		/// </remarks>
		public string SiteName 
		{
			get 
			{
				return siteName;
			}
			set 
			{
				siteName = value;
			}
		}
	
		/// <value>
		/// Sets and gets the URL for the Web Site.
		/// </value>
		/// <remarks>
		/// Sets and gets the value of <see cref="url"/> field.
		/// </remarks>
		public string URL 
		{
			get 
			{
				return url;
			}
			set 
			{
				url = ValidateUrl(value);
			}
		}
	
		/// <value>
		/// Sets and gets Web Site Description.
		/// </value>
		/// <remarks>
		/// Sets and gets the value of <see cref="description"/> field.
		/// </remarks>
		public string Description 
		{
			get 
			{
				return description;
			}
			set 
			{
				description = value;
			}
		}
	
		// Destructor

		/// <summary>
		/// Destructor
		/// </summary>
		/// <remarks>
		/// No Implementation
		/// </remarks>
		~WebSite() {}
	   
	}

	/// <summary>
	///    This object holds a collection of sites.
	/// </summary>
	public class SiteList 
	{
	
		/// <summary>
		/// Declared as a <see cref="SortedList"/> Collection Class.
		/// </summary>
		/// <seealso cref="System.Collections"/>
		protected SortedList sites;
	
		// Constructor
	
		/// <summary>
		/// Default Constructor
		/// </summary>
		/// <remarks>
		/// Initializes <see cref="sites"/>
		/// </remarks>
		public SiteList() 
		{
			sites = new SortedList();
		}
	
		// Properties

		/// <value>
		/// Gets the next valid index number to use.
		/// </value>
		/// <remarks>
		/// Gets the count of <see cref="sites"/> field.
		/// </remarks>
		public int NextIndex 
		{
			get 
			{
				return sites.Count;
			}
		}
	
		// Indexers
	
		/// <value>
		/// Adds and retrieves Web Site at index.
		/// </value>
		/// <remarks>
		/// Sets and gets the value of <see cref="sites"/> field.
		/// </remarks>
		/// <param name="index">
		/// Position in collection to get or set Web Site.
		/// </param>
		public WebSite this[int index] 
		{
			get 
			{
				if (index > sites.Count)
					return (WebSite)null;
				
				return (WebSite) sites.GetByIndex(index);
			}
			set 
			{
				if ( index < 10 )
					sites[index] = value;
			}
		}
	
		// Methods

		/// <summary>
		/// Deletes Web Site from sites
		/// </summary>
		/// <remarks>
		/// Removes the Web Site from the <see cref="sites"/> collection.
		/// </remarks>
		/// <param name="element">
		/// Index from where element will be deleted.
		/// </param>
		public void Remove(int element) 
		{
			sites.RemoveAt(element);
		}
	
	}
}
