using System.Collections.Generic;
using Arango.Client.Protocol;
using Arango.fastJSON;

namespace Arango.Client
{
    /// <summary>
    /// Arrango View support
    /// </summary>
    public class AView
    {
        readonly Dictionary<string, object> _parameters = new Dictionary<string, object>();
        readonly Connection _connection;

        internal AView(Connection connection)
        {
            _connection = connection;
        }

        #region arango view properties
        /// <summary>
        /// Determines type of the collection. Default value: Document.
        /// </summary>
        public AView Type(AViewType value)
        {
            // set enum format explicitely to override global setting 
            _parameters.Enum(ParameterName.Type, value, EnumFormat.String);

            return this;
        }

        /// <summary>
        /// adds possibility to add link collection do view
        /// </summary>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public AView Link(string collectionName)
        {
            _parameters.Object("links", collectionName  );
            return this;
        }

        #endregion

        #region Create view (POST)

        /// <summary>
        /// Creates new collection in current database context.
        /// </summary>
        public AResult<Dictionary<string, object>> Create(string viewName)
        {
            var request = new Request(HttpMethod.POST, ApiBaseUri.View, "");
            var bodyDocument = new Dictionary<string, object>();
            bodyDocument.String(ParameterName.Name, viewName);
            // optional
            Request.TrySetBodyParameter(ParameterName.Type, _parameters, bodyDocument);
            request.Body = JSON.ToJSON(bodyDocument, ASettings.JsonParameters);

            var response = _connection.Send(request);
            var result = new AResult<Dictionary<string, object>>(response);

            switch (response.StatusCode)
            {
                case 201:
                    var body = response.ParseBody<Dictionary<string, object>>();

                    result.Success = (body != null);
                    result.Value = body;
                    break;
                default:
                    // Arango error
                    break;
            }

            _parameters.Clear();

            return result;
        }

        #endregion

        #region GetView

        /// <summary>
        /// Retrieves basic information with additional properties about specified view.
        /// </summary>
        public AResult<Dictionary<string, object>> GetProperties(string viewName)
        {
            var request = new Request(HttpMethod.GET, ApiBaseUri.View, "/" + viewName + "/properties");

            var response = _connection.Send(request);
            var result = new AResult<Dictionary<string, object>>(response);

            switch (response.StatusCode)
            {
                case 200:
                case 201:
                    var body = response.ParseBody<Dictionary<string, object>>();

                    result.Success = (body != null);
                    result.Value = body;
                    break;
                case 400:
                case 404:
                default:
                    // Arango error
                    break;
            }

            _parameters.Clear();

            return result;
        }
        #endregion

        #region get view list (GET)

        /// <summary>
        /// Retrieves Arangodb view list
        /// </summary>
        /// <returns></returns>
        public AResult<Dictionary<string, object>> GetList()
        {
            var request = new Request(HttpMethod.GET, ApiBaseUri.View, "");

            var response = _connection.Send(request);
            var result = new AResult<Dictionary<string, object>>(response);

            switch (response.StatusCode)
            {
                case 200:
                case 201:
                    var body = response.ParseBody<Dictionary<string, object>>();

                    result.Success = (body != null);
                    result.Value = body;
                    break;
                case 400:
                case 404:
                default:
                    // Arango error
                    break;
            }

            _parameters.Clear();

            return result;
        }
        #endregion

        #region delete view
        /// <summary>
        /// deletes specified view
        /// </summary>
        /// <param name="viewName">name of view to delete</param>
        /// <returns>response result</returns>
        public AResult<Dictionary<string, object>> Delete(string viewName)
        {
            var request = new Request(HttpMethod.DELETE, ApiBaseUri.View, "/" + viewName );

            var response = _connection.Send(request);
            var result = new AResult<Dictionary<string, object>>(response);

            switch (response.StatusCode)
            {
                case 200:
                case 201:
                    var body = response.ParseBody<Dictionary<string, object>>();

                    result.Success = (body != null);
                    result.Value = body;
                    break;
                case 400:
                case 404:
                default:
                    // Arango error
                    break;
            }

            _parameters.Clear();

            return result;
        }
        #endregion

        #region modify/patch view definition
        public AResult<Dictionary<string, object>> ChangeProperties(string viewName,string collectionName)
        {
            var request = new Request(HttpMethod.PATCH, ApiBaseUri.View, "/"+viewName+ "/properties");
            var bodyDocument = new Dictionary<string, object>();
            Dictionary<string, object> links = new Dictionary<string, object>();
            ViewLink lintattr = new ViewLink();
            lintattr.analyzers[0] = "identity";
            lintattr.storeValues = "none";
            lintattr.trackListPositions = false;
            //otherwise it makes no sense
            lintattr.includeAllFields = true;
            lintattr.fields = new ViewFields();
            links.Add(collectionName,lintattr);
            bodyDocument.Object(ParameterName.Links, links);
            // optional
            //Request.TrySetBodyParameter(ParameterName.Links, _parameters, bodyDocument);
            request.Body = JSON.ToJSON(bodyDocument, ASettings.JsonParameters);

            var response = _connection.Send(request);
            var result = new AResult<Dictionary<string, object>>(response);

            switch (response.StatusCode)
            {
                case 201:
                    var body = response.ParseBody<Dictionary<string, object>>();

                    result.Success = (body != null);
                    result.Value = body;
                    break;
                default:
                    // Arango error
                    break;
            }

            _parameters.Clear();

            return result;
        }
        #endregion

    }
}
